using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Contracts.Contracts;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers;

public class GodMapper(IMapper<CreateGodBasicAttackDto, GodBasicAttack> godBasicAttackMapper) : Mapper<CreateGodDto, God>
{
    private readonly IMapper<CreateGodBasicAttackDto, GodBasicAttack> _godBasicAttackMapper = godBasicAttackMapper;

    public override God Map(CreateGodDto input)
    {
        return new God
        {
            SmiteId = input.SmiteId,
            Name = input.Name,
            Title = input.Title,
            Pantheon = input.Pantheon,
            Type = input.Type,
            Pros = input.Pros,
            Speed = input.Speed,
            Health = input.Health,
            HealthPerLevel = input.HealthPerLevel,
            Mana = input.Mana,
            ManaPerLevel = input.ManaPerLevel,
            AttackSpeed = input.AttackSpeed,
            AttackSpeedPerLevel = input.AttackSpeedPerLevel,
            AutoBanned = input.AutoBanned,
            Checksum = input.Checksum,
            GodCardUrl = input.GodCardUrl,
            GodIconUrl = input.GodIconUrl,
            HealthPerFive = input.HealthPerFive,
            Hp5PerLevel = input.Hp5PerLevel,
            LatestGod = input.LatestGod,
            Lore = input.Lore,
            Mp5PerLevel = input.Mp5PerLevel,
            MagicProtection = input.MagicProtection,
            MagicProtectionPerLevel = input.MagicProtectionPerLevel,
            MagicalPower = input.MagicalPower,
            MagicalPowerPerLevel = input.MagicalPowerPerLevel,
            ManaPerFive = input.ManaPerFive,
            PhysicalPower = input.PhysicalPower,
            OnFreeRotation = input.OnFreeRotation,
            PhysicalPowerPerLevel = input.PhysicalPowerPerLevel,
            PhysicalProtection = input.PhysicalProtection,
            PhysicalProtectionPerLevel = input.PhysicalProtectionPerLevel,
            Role = input.Role,
            GodBasicAttacks = input.GodBasicAttackDto.Select(_godBasicAttackMapper.Map).ToList(),
            Latest = true // If we map it from a CreateDto, it's always the latest
        };
    }
}
