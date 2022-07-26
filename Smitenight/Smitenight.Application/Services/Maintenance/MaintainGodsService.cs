using Microsoft.EntityFrameworkCore;
using Smitenight.Abstractions.Application.Services.Maintenance;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses.GodResponses;
using Smitenight.Domain.Constants.SmiteClient.Responses;
using Smitenight.Domain.Enums.Ability;
using Smitenight.Domain.Enums.Gods;
using Smitenight.Domain.Enums.SmiteClient;
using Smitenight.Domain.Models.Abilities;
using Smitenight.Domain.Models.Gods;
using Smitenight.Persistence;

namespace Smitenight.Application.Services.Maintenance
{
    public class MaintainGodsService : IMaintainGodsService
    {
        private readonly IGodSmiteClient _godSmiteClient;
        private readonly SmitenightDbContext _dbContext;

        public MaintainGodsService(
            IGodSmiteClient godSmiteClient,
            SmitenightDbContext dbContext)
        {
            _godSmiteClient = godSmiteClient;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Adds new gods and updates all existing ones
        /// This includes the abilities and basic attacks
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task MaintainAsync(string sessionId, CancellationToken cancellationToken = default)
        {
            var godsRequest = new GodsRequest(sessionId, LanguageCodeEnum.English);
            var godsResponse = await _godSmiteClient.GetGodsAsync(godsRequest, cancellationToken);
            if (godsResponse?.Response == null)
            {
                return;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                foreach (var god in godsResponse.Response)
                {
                    var existingGodEntity = await _dbContext.Gods.AsNoTracking()
                        .Include(x => x.Abilities)
                        .SingleOrDefaultAsync(x => x.SmiteId == god.Id, cancellationToken);
                    if (existingGodEntity != null)
                    {
                        await UpdateGodAsync(existingGodEntity, god, cancellationToken);
                    }
                    else
                    {
                        AddGod(god);
                    }
                }

                await _dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Starts adding new gods and their descriptions to the database
        /// </summary>
        /// <param name="god"></param>
        /// <returns></returns>
        private void AddGod(GodsResponse god)
        {
            var godEntity = BuildGodEntity(god);
            _dbContext.Gods.Add(godEntity);
        }

        /// <summary>
        /// Updates existing gods and replacing their descriptions
        /// </summary>
        /// <param name="existingGodEntity"></param>
        /// <param name="god"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task UpdateGodAsync(God existingGodEntity, GodsResponse god, CancellationToken cancellationToken)
        {
            var abilityIds = existingGodEntity.Abilities.Select(x => x.Id).ToList();
            _dbContext.BasicAttackDescriptions.RemoveRange(await _dbContext.BasicAttackDescriptions.Where(x => x.GodId == existingGodEntity.Id).ToListAsync(cancellationToken));
            _dbContext.AbilityRanks.RemoveRange(await _dbContext.AbilityRanks.Where(x => abilityIds.Contains(x.AbilityId)).ToListAsync(cancellationToken));
            _dbContext.AbilityTags.RemoveRange(await _dbContext.AbilityTags.Where(x => abilityIds.Contains(x.AbilityId)).ToListAsync(cancellationToken));

            var godEntity = BuildGodEntity(god);
            godEntity.Id = existingGodEntity.Id;
            godEntity.Abilities.ForEach(ability =>
            {
                ability.Id = existingGodEntity.Abilities.Single(x => x.AbilityType == ability.AbilityType).Id;
            });
            
            _dbContext.Gods.Update(godEntity);
        }

        /// <summary>
        /// Builds a new god entity based on the response from the API
        /// </summary>
        /// <param name="god"></param>
        /// <returns></returns>
        private God BuildGodEntity(GodsResponse god)
        {
            return new God
            {
                AttackSpeed = god.AttackSpeed,
                AttackSpeedPerLevel = god.AttackSpeedPerLevel,
                AutoBanned = god.AutoBanned == ResponseConstants.Yes,
                GodCardUrl = god.GodCardUrl,
                GodIconUrl = god.GodIconUrl,
                Health = god.Health,
                HealthPerFive = god.HealthPerFive,
                HealthPerLevel = god.HealthPerLevel,
                Hp5PerLevel = god.Hp5PerLevel,
                LatestGod = god.LatestGod == ResponseConstants.Yes,
                Lore = god.Lore,
                MagicProtection = god.MagicProtection,
                MagicProtectionPerLevel = god.MagicProtectionPerLevel,
                MagicalPower = god.MagicalPower,
                MagicalPowerPerLevel = god.MagicalPowerPerLevel,
                Mana = god.Mana,
                ManaPerFive = god.ManaPerFive,
                ManaPerLevel = god.ManaPerLevel,
                Mp5PerLevel = god.Mp5PerLevel,
                Name = god.Name,
                OnFreeRotation = god.OnFreeRotation == ResponseConstants.Yes,
                Pantheon = god.Pantheon,
                PhysicalPower = god.PhysicalPower,
                PhysicalPowerPerLevel = god.PhysicalPowerPerLevel,
                PhysicalProtection = god.PhysicalProtection,
                PhysicalProtectionPerLevel = god.PhysicalProtectionPerLevel,
                Pros = god.Pros,
                Role = ConvertToGodRoleEnum(god.Roles),
                SmiteId = god.Id,
                Speed = god.Speed,
                Title = god.Title,
                Type = ConvertToGodTypeEnum(god.Type),
                Abilities = new List<Ability>
                {
                    new()
                    {
                        AbilityType = AbilityTypeEnum.Primary,
                        Cooldown = !string.IsNullOrWhiteSpace(god.AbilityDetails1.Description.ItemDescription.Cooldown) ? god.AbilityDetails1.Description.ItemDescription.Cooldown : null,
                        Cost = !string.IsNullOrWhiteSpace(god.AbilityDetails1.Description.ItemDescription.Cost) ? god.AbilityDetails1.Description.ItemDescription.Cost : null,
                        Description = god.AbilityDetails1.Description.ItemDescription.Description,
                        SmiteId = god.AbilityDetails1.Id,
                        Summary = god.AbilityDetails1.Summary,
                        Url = god.AbilityDetails1.Url,
                        AbilityRanks = god.AbilityDetails1.Description.ItemDescription.RankItems.Select(rankItem => new AbilityRank
                        {
                            Description = rankItem.Description,
                            Value = rankItem.Value
                        }).ToList(),
                        AbilityTags = god.AbilityDetails1.Description.ItemDescription.MenuItems.Select(menuItem => new AbilityTag
                        {
                            Description = menuItem.Description,
                            Value = menuItem.Value
                        }).ToList()
                    },
                    new()
                    {
                        AbilityType = AbilityTypeEnum.Secondary,
                        Cooldown = !string.IsNullOrWhiteSpace(god.AbilityDetails2.Description.ItemDescription.Cooldown) ? god.AbilityDetails2.Description.ItemDescription.Cooldown : null,
                        Cost = !string.IsNullOrWhiteSpace(god.AbilityDetails2.Description.ItemDescription.Cost) ? god.AbilityDetails2.Description.ItemDescription.Cost : null,
                        Description = god.AbilityDetails2.Description.ItemDescription.Description,
                        SmiteId = god.AbilityDetails2.Id,
                        Summary = god.AbilityDetails2.Summary,
                        Url = god.AbilityDetails2.Url,
                        AbilityRanks = god.AbilityDetails2.Description.ItemDescription.RankItems.Select(rankItem => new AbilityRank
                        {
                            Description = rankItem.Description,
                            Value = rankItem.Value
                        }).ToList(),
                        AbilityTags = god.AbilityDetails2.Description.ItemDescription.MenuItems.Select(menuItem => new AbilityTag
                        {
                            Description = menuItem.Description,
                            Value = menuItem.Value
                        }).ToList()
                    },
                    new()
                    {
                        AbilityType = AbilityTypeEnum.Tertiary,
                        Cooldown = !string.IsNullOrWhiteSpace(god.AbilityDetails3.Description.ItemDescription.Cooldown) ? god.AbilityDetails3.Description.ItemDescription.Cooldown : null,
                        Cost = !string.IsNullOrWhiteSpace(god.AbilityDetails3.Description.ItemDescription.Cost) ? god.AbilityDetails3.Description.ItemDescription.Cost : null,
                        Description = god.AbilityDetails3.Description.ItemDescription.Description,
                        SmiteId = god.AbilityDetails3.Id,
                        Summary = god.AbilityDetails3.Summary,
                        Url = god.AbilityDetails3.Url,
                        AbilityRanks = god.AbilityDetails3.Description.ItemDescription.RankItems.Select(rankItem => new AbilityRank
                        {
                            Description = rankItem.Description,
                            Value = rankItem.Value
                        }).ToList(),
                        AbilityTags = god.AbilityDetails3.Description.ItemDescription.MenuItems.Select(menuItem => new AbilityTag
                        {
                            Description = menuItem.Description,
                            Value = menuItem.Value
                        }).ToList()
                    },
                    new()
                    {
                        AbilityType = AbilityTypeEnum.Ultimate,
                        Cooldown = !string.IsNullOrWhiteSpace(god.AbilityDetails4.Description.ItemDescription.Cooldown) ? god.AbilityDetails4.Description.ItemDescription.Cooldown : null,
                        Cost = !string.IsNullOrWhiteSpace(god.AbilityDetails4.Description.ItemDescription.Cost) ? god.AbilityDetails4.Description.ItemDescription.Cost : null,
                        Description = god.AbilityDetails4.Description.ItemDescription.Description,
                        SmiteId = god.AbilityDetails4.Id,
                        Summary = god.AbilityDetails4.Summary,
                        Url = god.AbilityDetails4.Url,
                        AbilityRanks = god.AbilityDetails4.Description.ItemDescription.RankItems.Select(rankItem => new AbilityRank
                        {
                            Description = rankItem.Description,
                            Value = rankItem.Value
                        }).ToList(),
                        AbilityTags = god.AbilityDetails4.Description.ItemDescription.MenuItems.Select(menuItem => new AbilityTag
                        {
                            Description = menuItem.Description,
                            Value = menuItem.Value
                        }).ToList()
                    },
                    new()
                    {
                        AbilityType = AbilityTypeEnum.Passive,
                        Cooldown = !string.IsNullOrWhiteSpace(god.AbilityDetails5.Description.ItemDescription.Cooldown) ? god.AbilityDetails5.Description.ItemDescription.Cooldown : null,
                        Cost = !string.IsNullOrWhiteSpace(god.AbilityDetails5.Description.ItemDescription.Cost) ? god.AbilityDetails5.Description.ItemDescription.Cost : null,
                        Description = god.AbilityDetails5.Description.ItemDescription.Description,
                        SmiteId = god.AbilityDetails5.Id,
                        Summary = god.AbilityDetails5.Summary,
                        Url = god.AbilityDetails5.Url,
                        AbilityRanks = god.AbilityDetails5.Description.ItemDescription.RankItems.Select(rankItem => new AbilityRank
                        {
                            Description = rankItem.Description,
                            Value = rankItem.Value
                        }).ToList(),
                        AbilityTags = god.AbilityDetails5.Description.ItemDescription.MenuItems.Select(menuItem => new AbilityTag
                        {
                            Description = menuItem.Description,
                            Value = menuItem.Value
                        }).ToList()
                    }
                },
                BasicAttackDescriptions = god.BasicAttack.ItemDescription.MenuItems.Select(basicAttack => new BasicAttackDescription
                {
                    Description = basicAttack.Description,
                    Value = basicAttack.Value
                }).ToList()
            };
        }

        /// <summary>
        /// Converts a god role string to <see cref="GodRoleEnum"/>
        /// </summary>
        /// <param name="godRoles"></param>
        /// <returns></returns>
        private GodRoleEnum ConvertToGodRoleEnum(string godRoles) => godRoles switch
        {
            GodResponseConstants.WarriorRole => GodRoleEnum.Warrior,
            GodResponseConstants.MageRole => GodRoleEnum.Mage,
            GodResponseConstants.HunterRole => GodRoleEnum.Hunter,
            GodResponseConstants.AssassinRole => GodRoleEnum.Assassin,
            GodResponseConstants.GuardianRole => GodRoleEnum.Guardian,
            _ => GodRoleEnum.Unknown
        };

        /// <summary>
        /// Converts a god type string to <see cref="GodTypeEnum"/>
        /// </summary>
        /// <param name="godType"></param>
        /// <returns></returns>
        private GodTypeEnum ConvertToGodTypeEnum(string godType) => godType switch
        {
            GodResponseConstants.MeleePhysicalType => GodTypeEnum.MeleePhysical,
            GodResponseConstants.MeleeMagicalType => GodTypeEnum.MeleeMagical,
            GodResponseConstants.RangedPhysicalType => GodTypeEnum.RangedPhysical,
            GodResponseConstants.RangedMagicalType => GodTypeEnum.RangedMagical,
            _ => GodTypeEnum.Unknown
        };
    }
}
