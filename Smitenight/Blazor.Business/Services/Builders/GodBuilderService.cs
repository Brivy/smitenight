using Smitenight.Application.Blazor.Business.Constants;
using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;

namespace Smitenight.Application.Blazor.Business.Services.Builders
{
    public class GodBuilderService : IGodBuilderService
    {
        /// <summary>
        /// Builds a new <see cref="God"/> entity based on the response from the API
        /// </summary>
        /// <param name="godResponse"></param>
        /// <param name="godSkinsResponse"></param>
        /// <returns></returns>
        public God Build(GodsResponse godResponse, List<GodSkinsResponse> godSkinsResponse)
        {
            return new God
            {
                AttackSpeed = godResponse.AttackSpeed,
                AttackSpeedPerLevel = godResponse.AttackSpeedPerLevel,
                AutoBanned = godResponse.AutoBanned == SmiteConstants.Yes,
                GodCardUrl = godResponse.GodCardUrl,
                GodIconUrl = godResponse.GodIconUrl,
                Health = godResponse.Health,
                HealthPerFive = godResponse.HealthPerFive,
                HealthPerLevel = godResponse.HealthPerLevel,
                Hp5PerLevel = godResponse.Hp5PerLevel,
                LatestGod = godResponse.LatestGod == SmiteConstants.Yes,
                Lore = godResponse.Lore,
                MagicProtection = godResponse.MagicProtection,
                MagicProtectionPerLevel = godResponse.MagicProtectionPerLevel,
                MagicalPower = godResponse.MagicalPower,
                MagicalPowerPerLevel = godResponse.MagicalPowerPerLevel,
                Mana = godResponse.Mana,
                ManaPerFive = godResponse.ManaPerFive,
                ManaPerLevel = godResponse.ManaPerLevel,
                Mp5PerLevel = godResponse.Mp5PerLevel,
                Name = godResponse.Name,
                OnFreeRotation = godResponse.OnFreeRotation == SmiteConstants.Yes,
                Pantheon = godResponse.Pantheon,
                PhysicalPower = godResponse.PhysicalPower,
                PhysicalPowerPerLevel = godResponse.PhysicalPowerPerLevel,
                PhysicalProtection = godResponse.PhysicalProtection,
                PhysicalProtectionPerLevel = godResponse.PhysicalProtectionPerLevel,
                Pros = godResponse.Pros,
                Role = ConvertToGodRoleEnum(godResponse.Roles),
                SmiteId = godResponse.Id,
                Speed = godResponse.Speed,
                Title = godResponse.Title,
                Type = ConvertToGodTypeEnum(godResponse.Type),
                Abilities = new List<Ability>
                {
                    new()
                    {
                        AbilityType = AbilityTypeEnum.Primary,
                        Cooldown = !string.IsNullOrWhiteSpace(godResponse.AbilityDetails1.Description.ItemDescription.Cooldown) ? godResponse.AbilityDetails1.Description.ItemDescription.Cooldown : null,
                        Cost = !string.IsNullOrWhiteSpace(godResponse.AbilityDetails1.Description.ItemDescription.Cost) ? godResponse.AbilityDetails1.Description.ItemDescription.Cost : null,
                        Description = godResponse.AbilityDetails1.Description.ItemDescription.Description,
                        SmiteId = godResponse.AbilityDetails1.Id,
                        Summary = godResponse.AbilityDetails1.Summary,
                        Url = godResponse.AbilityDetails1.Url,
                        AbilityRanks = godResponse.AbilityDetails1.Description.ItemDescription.RankItems.Select(rankItem => new AbilityRank
                        {
                            Description = rankItem.Description,
                            Value = rankItem.Value
                        }).ToList(),
                        AbilityTags = godResponse.AbilityDetails1.Description.ItemDescription.MenuItems.Select(menuItem => new AbilityTag
                        {
                            Description = menuItem.Description,
                            Value = menuItem.Value
                        }).ToList()
                    },
                    new()
                    {
                        AbilityType = AbilityTypeEnum.Secondary,
                        Cooldown = !string.IsNullOrWhiteSpace(godResponse.AbilityDetails2.Description.ItemDescription.Cooldown) ? godResponse.AbilityDetails2.Description.ItemDescription.Cooldown : null,
                        Cost = !string.IsNullOrWhiteSpace(godResponse.AbilityDetails2.Description.ItemDescription.Cost) ? godResponse.AbilityDetails2.Description.ItemDescription.Cost : null,
                        Description = godResponse.AbilityDetails2.Description.ItemDescription.Description,
                        SmiteId = godResponse.AbilityDetails2.Id,
                        Summary = godResponse.AbilityDetails2.Summary,
                        Url = godResponse.AbilityDetails2.Url,
                        AbilityRanks = godResponse.AbilityDetails2.Description.ItemDescription.RankItems.Select(rankItem => new AbilityRank
                        {
                            Description = rankItem.Description,
                            Value = rankItem.Value
                        }).ToList(),
                        AbilityTags = godResponse.AbilityDetails2.Description.ItemDescription.MenuItems.Select(menuItem => new AbilityTag
                        {
                            Description = menuItem.Description,
                            Value = menuItem.Value
                        }).ToList()
                    },
                    new()
                    {
                        AbilityType = AbilityTypeEnum.Tertiary,
                        Cooldown = !string.IsNullOrWhiteSpace(godResponse.AbilityDetails3.Description.ItemDescription.Cooldown) ? godResponse.AbilityDetails3.Description.ItemDescription.Cooldown : null,
                        Cost = !string.IsNullOrWhiteSpace(godResponse.AbilityDetails3.Description.ItemDescription.Cost) ? godResponse.AbilityDetails3.Description.ItemDescription.Cost : null,
                        Description = godResponse.AbilityDetails3.Description.ItemDescription.Description,
                        SmiteId = godResponse.AbilityDetails3.Id,
                        Summary = godResponse.AbilityDetails3.Summary,
                        Url = godResponse.AbilityDetails3.Url,
                        AbilityRanks = godResponse.AbilityDetails3.Description.ItemDescription.RankItems.Select(rankItem => new AbilityRank
                        {
                            Description = rankItem.Description,
                            Value = rankItem.Value
                        }).ToList(),
                        AbilityTags = godResponse.AbilityDetails3.Description.ItemDescription.MenuItems.Select(menuItem => new AbilityTag
                        {
                            Description = menuItem.Description,
                            Value = menuItem.Value
                        }).ToList()
                    },
                    new()
                    {
                        AbilityType = AbilityTypeEnum.Ultimate,
                        Cooldown = !string.IsNullOrWhiteSpace(godResponse.AbilityDetails4.Description.ItemDescription.Cooldown) ? godResponse.AbilityDetails4.Description.ItemDescription.Cooldown : null,
                        Cost = !string.IsNullOrWhiteSpace(godResponse.AbilityDetails4.Description.ItemDescription.Cost) ? godResponse.AbilityDetails4.Description.ItemDescription.Cost : null,
                        Description = godResponse.AbilityDetails4.Description.ItemDescription.Description,
                        SmiteId = godResponse.AbilityDetails4.Id,
                        Summary = godResponse.AbilityDetails4.Summary,
                        Url = godResponse.AbilityDetails4.Url,
                        AbilityRanks = godResponse.AbilityDetails4.Description.ItemDescription.RankItems.Select(rankItem => new AbilityRank
                        {
                            Description = rankItem.Description,
                            Value = rankItem.Value
                        }).ToList(),
                        AbilityTags = godResponse.AbilityDetails4.Description.ItemDescription.MenuItems.Select(menuItem => new AbilityTag
                        {
                            Description = menuItem.Description,
                            Value = menuItem.Value
                        }).ToList()
                    },
                    new()
                    {
                        AbilityType = AbilityTypeEnum.Passive,
                        Cooldown = !string.IsNullOrWhiteSpace(godResponse.AbilityDetails5.Description.ItemDescription.Cooldown) ? godResponse.AbilityDetails5.Description.ItemDescription.Cooldown : null,
                        Cost = !string.IsNullOrWhiteSpace(godResponse.AbilityDetails5.Description.ItemDescription.Cost) ? godResponse.AbilityDetails5.Description.ItemDescription.Cost : null,
                        Description = godResponse.AbilityDetails5.Description.ItemDescription.Description,
                        SmiteId = godResponse.AbilityDetails5.Id,
                        Summary = godResponse.AbilityDetails5.Summary,
                        Url = godResponse.AbilityDetails5.Url,
                        AbilityRanks = godResponse.AbilityDetails5.Description.ItemDescription.RankItems.Select(rankItem => new AbilityRank
                        {
                            Description = rankItem.Description,
                            Value = rankItem.Value
                        }).ToList(),
                        AbilityTags = godResponse.AbilityDetails5.Description.ItemDescription.MenuItems.Select(menuItem => new AbilityTag
                        {
                            Description = menuItem.Description,
                            Value = menuItem.Value
                        }).ToList()
                    }
                },
                BasicAttackDescriptions = godResponse.BasicAttack.ItemDescription.MenuItems.Select(basicAttack => new BasicAttackDescription
                {
                    Description = basicAttack.Description,
                    Value = basicAttack.Value
                }).ToList(),
                GodSkins = godSkinsResponse.Select(godSkin => new GodSkin
                {
                    GodSkinUrl = !string.IsNullOrWhiteSpace(godSkin.GodSkinUrl) ? godSkin.GodSkinUrl : null,
                    Name = godSkin.SkinName,
                    Obtainability = ConvertToGodSkinsObtainabilityEnum(godSkin.Obtainability),
                    PriceFavor = godSkin.PriceFavor,
                    PriceGems = godSkin.PriceGems,
                    SecondarySmiteId = godSkin.SkinId2,
                    SmiteId = godSkin.SkinId1
                }).ToList()
            };
        }

        #region Converters

        /// <summary>
        /// Converts a god role string to <see cref="GodRoleEnum"/>
        /// </summary>
        /// <param name="godRoles"></param>
        /// <returns></returns>
        private GodRoleEnum ConvertToGodRoleEnum(string godRoles) => godRoles switch
        {
            GodConstants.WarriorRole => GodRoleEnum.Warrior,
            GodConstants.MageRole => GodRoleEnum.Mage,
            GodConstants.HunterRole => GodRoleEnum.Hunter,
            GodConstants.AssassinRole => GodRoleEnum.Assassin,
            GodConstants.GuardianRole => GodRoleEnum.Guardian,
            _ => GodRoleEnum.Unknown
        };

        /// <summary>
        /// Converts a god type string to <see cref="GodTypeEnum"/>
        /// </summary>
        /// <param name="godType"></param>
        /// <returns></returns>
        private GodTypeEnum ConvertToGodTypeEnum(string godType) => godType switch
        {
            GodConstants.MeleePhysicalType => GodTypeEnum.MeleePhysical,
            GodConstants.MeleeMagicalType => GodTypeEnum.MeleeMagical,
            GodConstants.RangedPhysicalType => GodTypeEnum.RangedPhysical,
            GodConstants.RangedMagicalType => GodTypeEnum.RangedMagical,
            _ => GodTypeEnum.Unknown
        };

        /// <summary>
        /// Converts a obtainability string to <see cref="GodSkinsObtainabilityEnum"/>
        /// </summary>
        /// <param name="obtainability"></param>
        /// <returns></returns>
        private GodSkinsObtainabilityEnum ConvertToGodSkinsObtainabilityEnum(string obtainability) => obtainability switch
        {
            GodConstants.NormalObtainability => GodSkinsObtainabilityEnum.Normal,
            GodConstants.CrossoverObtainability => GodSkinsObtainabilityEnum.Crossover,
            GodConstants.LimitedObtainability => GodSkinsObtainabilityEnum.Limited,
            GodConstants.ExclusiveObtainability => GodSkinsObtainabilityEnum.Exclusive,
            _ => GodSkinsObtainabilityEnum.Unknown
        };

        #endregion
    }
}
