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
                Role = ConvertToGodRole(god.Roles),
                SmiteId = god.Id,
                Speed = god.Speed,
                Title = god.Title,
                Type = ConvertToGodType(god.Type)
            };
        }

        private static GodRole ConvertToGodRole(string godRoles) => godRoles switch
        {
            GodConstants.WarriorRole => GodRole.Warrior,
            GodConstants.MageRole => GodRole.Mage,
            GodConstants.HunterRole => GodRole.Hunter,
            GodConstants.AssassinRole => GodRole.Assassin,
            GodConstants.GuardianRole => GodRole.Guardian,
            _ => GodRole.Unknown
        };

        private static GodType ConvertToGodType(string godType) => godType switch
        {
            GodConstants.MeleePhysicalType => GodType.MeleePhysical,
            GodConstants.MeleeMagicalType => GodType.MeleeMagical,
            GodConstants.RangedPhysicalType => GodType.RangedPhysical,
            GodConstants.RangedMagicalType => GodType.RangedMagical,
            _ => GodType.Unknown
        };
    }
}
