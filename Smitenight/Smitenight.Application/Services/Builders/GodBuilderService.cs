﻿using Smitenight.Abstractions.Application.Services.Builders;
using Smitenight.Domain.Clients.SmiteClient.Responses.GodResponses;
using Smitenight.Domain.Constants.SmiteClient.Responses;
using Smitenight.Domain.Enums.Ability;
using Smitenight.Domain.Enums.Gods;
using Smitenight.Domain.Models.Abilities;
using Smitenight.Domain.Models.Gods;

namespace Smitenight.Application.Services.Builders
{
    public class GodBuilderService : IGodBuilderService
    {
        /// <summary>
        /// Builds a new <see cref="God"/> entity based on the response from the API
        /// </summary>
        /// <param name="god"></param>
        /// <param name="godSkins"></param>
        /// <returns></returns>
        public God Build(GodsResponse god, List<GodSkinsResponse> godSkins)
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
                }).ToList(),
                GodSkins = godSkins.Select(godSkin => new GodSkin
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

        /// <summary>
        /// Converts a obtainability string to <see cref="GodSkinsObtainabilityEnum"/>
        /// </summary>
        /// <param name="obtainability"></param>
        /// <returns></returns>
        private GodSkinsObtainabilityEnum ConvertToGodSkinsObtainabilityEnum(string obtainability) => obtainability switch
        {
            GodResponseConstants.NormalObtainability => GodSkinsObtainabilityEnum.Normal,
            GodResponseConstants.CrossoverObtainability => GodSkinsObtainabilityEnum.Crossover,
            GodResponseConstants.LimitedObtainability => GodSkinsObtainabilityEnum.Limited,
            GodResponseConstants.ExclusiveObtainability => GodSkinsObtainabilityEnum.Exclusive,
            _ => GodSkinsObtainabilityEnum.Unknown
        };

        #endregion
    }
}
