using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Smitenight.Abstractions.Application.Services.Maintenance;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses.GodResponses;
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
                        await UpdateGodsAsync(existingGodEntity, god, cancellationToken);
                    }
                    else
                    {
                        await AddGodsAsync(god, cancellationToken);
                    }
                }

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task AddGodsAsync(GodsResponse god, CancellationToken cancellationToken)
        {
            var godEntity = new God
            {
                AttackSpeed = god.AttackSpeed,
                AttackSpeedPerLevel = god.AttackSpeedPerLevel,
                AutoBanned = god.AutoBanned,
                Cons = god.Cons,
                GodCardUrl = god.GodCardUrl,
                GodIconUrl = god.GodIconUrl,
                Health = god.Health,
                HealthPerFive = god.HealthPerFive,
                HealthPerLevel = god.HealthPerLevel,
                Hp5PerLevel = god.Hp5PerLevel,
                LatestGod = god.LatestGod,
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
                OnFreeRotation = god.OnFreeRotation,
                Pantheon = god.Pantheon,
                PhysicalPower = god.PhysicalPower,
                PhysicalPowerPerLevel = god.PhysicalPowerPerLevel,
                PhysicalProtection = god.PhysicalProtection,
                PhysicalProtectionPerLevel = god.PhysicalProtectionPerLevel,
                Pros = god.Pros,
                Roles = god.Roles,
                SmiteId = god.Id,
                Speed = god.Speed,
                Title = god.Title,
                Type = god.Type,
                Abilities = new List<Ability>
                {
                    new()
                    {
                        Cooldown = god.AbilityDetails1.Description.ItemDescription.Cooldown,
                        Cost = god.AbilityDetails1.Description.ItemDescription.Cost,
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
                        Cooldown = god.AbilityDetails2.Description.ItemDescription.Cooldown,
                        Cost = god.AbilityDetails2.Description.ItemDescription.Cost,
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
                        Cooldown = god.AbilityDetails3.Description.ItemDescription.Cooldown,
                        Cost = god.AbilityDetails3.Description.ItemDescription.Cost,
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
                        Cooldown = god.AbilityDetails4.Description.ItemDescription.Cooldown,
                        Cost = god.AbilityDetails4.Description.ItemDescription.Cost,
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
                        Cooldown = god.AbilityDetails5.Description.ItemDescription.Cooldown,
                        Cost = god.AbilityDetails5.Description.ItemDescription.Cost,
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

            _dbContext.Gods.Add(godEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task UpdateGodsAsync(God existingGodEntity, GodsResponse god, CancellationToken cancellationToken)
        {
            var abilityIds = existingGodEntity.Abilities.Select(x => x.Id).ToList();
            _dbContext.BasicAttackDescriptions.RemoveRange(await _dbContext.BasicAttackDescriptions.AsNoTracking().Where(x => x.GodId == existingGodEntity.Id).ToListAsync(cancellationToken));
            _dbContext.AbilityRanks.RemoveRange(await _dbContext.AbilityRanks.AsNoTracking().Where(x => abilityIds.Contains(x.AbilityId)).ToListAsync(cancellationToken));
            _dbContext.AbilityTags.RemoveRange(await _dbContext.AbilityTags.AsNoTracking().Where(x => abilityIds.Contains(x.AbilityId)).ToListAsync(cancellationToken));

            await _dbContext.SaveChangesAsync(cancellationToken);

            var godEntity = new God
            {
                Id = existingGodEntity.Id,
                AttackSpeed = god.AttackSpeed,
                AttackSpeedPerLevel = god.AttackSpeedPerLevel,
                AutoBanned = god.AutoBanned,
                Cons = god.Cons,
                GodCardUrl = god.GodCardUrl,
                GodIconUrl = god.GodIconUrl,
                Health = god.Health,
                HealthPerFive = god.HealthPerFive,
                HealthPerLevel = god.HealthPerLevel,
                Hp5PerLevel = god.Hp5PerLevel,
                LatestGod = god.LatestGod,
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
                OnFreeRotation = god.OnFreeRotation,
                Pantheon = god.Pantheon,
                PhysicalPower = god.PhysicalPower,
                PhysicalPowerPerLevel = god.PhysicalPowerPerLevel,
                PhysicalProtection = god.PhysicalProtection,
                PhysicalProtectionPerLevel = god.PhysicalProtectionPerLevel,
                Pros = god.Pros,
                Roles = god.Roles,
                SmiteId = god.Id,
                Speed = god.Speed,
                Title = god.Title,
                Type = god.Type,
                Abilities = new List<Ability>
                {
                    new()
                    {
                        Id = existingGodEntity.Abilities.Single(x => x.SmiteId == god.AbilityDetails1.Id).Id,
                        Cooldown = god.AbilityDetails1.Description.ItemDescription.Cooldown,
                        Cost = god.AbilityDetails1.Description.ItemDescription.Cost,
                        Description = god.AbilityDetails1.Description.ItemDescription.Description,
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
                        Id = existingGodEntity.Abilities.Single(x => x.SmiteId == god.AbilityDetails2.Id).Id,
                        Cooldown = god.AbilityDetails2.Description.ItemDescription.Cooldown,
                        Cost = god.AbilityDetails2.Description.ItemDescription.Cost,
                        Description = god.AbilityDetails2.Description.ItemDescription.Description,
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
                        Id = existingGodEntity.Abilities.Single(x => x.SmiteId == god.AbilityDetails3.Id).Id,
                        Cooldown = god.AbilityDetails3.Description.ItemDescription.Cooldown,
                        Cost = god.AbilityDetails3.Description.ItemDescription.Cost,
                        Description = god.AbilityDetails3.Description.ItemDescription.Description,
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
                        Id = existingGodEntity.Abilities.Single(x => x.SmiteId == god.AbilityDetails4.Id).Id,
                        Cooldown = god.AbilityDetails4.Description.ItemDescription.Cooldown,
                        Cost = god.AbilityDetails4.Description.ItemDescription.Cost,
                        Description = god.AbilityDetails4.Description.ItemDescription.Description,
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
                        Id = existingGodEntity.Abilities.Single(x => x.SmiteId == god.AbilityDetails5.Id).Id,
                        Cooldown = god.AbilityDetails5.Description.ItemDescription.Cooldown,
                        Cost = god.AbilityDetails5.Description.ItemDescription.Cost,
                        Description = god.AbilityDetails5.Description.ItemDescription.Description,
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

            _dbContext.Gods.Update(godEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
