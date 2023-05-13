using Smitenight.Application.Blazor.Business.Constants;
using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateGodMapper : Mapper<GodDto, CreateGodDto>
    {
        public override CreateGodDto Map(GodDto god)
        {
            return new CreateGodDto
            {
                AttackSpeed = god.AttackSpeed,
                AttackSpeedPerLevel = god.AttackSpeedPerLevel,
                AutoBanned = god.AutoBanned == SmiteConstants.Yes,
                GodCardUrl = god.GodCardUrl,
                GodIconUrl = god.GodIconUrl,
                Health = god.Health,
                HealthPerFive = god.HealthPerFive,
                HealthPerLevel = god.HealthPerLevel,
                Hp5PerLevel = god.Hp5PerLevel,
                LatestGod = god.LatestGod == SmiteConstants.Yes,
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
                OnFreeRotation = god.OnFreeRotation == SmiteConstants.Yes,
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
                Type = ConvertToGodTypeEnum(god.Type)
            };
        }

        private GodRoleEnum ConvertToGodRoleEnum(string godRoles) => godRoles switch
        {
            GodConstants.WarriorRole => GodRoleEnum.Warrior,
            GodConstants.MageRole => GodRoleEnum.Mage,
            GodConstants.HunterRole => GodRoleEnum.Hunter,
            GodConstants.AssassinRole => GodRoleEnum.Assassin,
            GodConstants.GuardianRole => GodRoleEnum.Guardian,
            _ => GodRoleEnum.Unknown
        };

        private GodTypeEnum ConvertToGodTypeEnum(string godType) => godType switch
        {
            GodConstants.MeleePhysicalType => GodTypeEnum.MeleePhysical,
            GodConstants.MeleeMagicalType => GodTypeEnum.MeleeMagical,
            GodConstants.RangedPhysicalType => GodTypeEnum.RangedPhysical,
            GodConstants.RangedMagicalType => GodTypeEnum.RangedMagical,
            _ => GodTypeEnum.Unknown
        };
    }
}
