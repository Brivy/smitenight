using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.Contracts.Models;

public record CreateGodDto
{
    public required int SmiteId { get; init; }
    public required string Checksum { get; init; }
    public float AttackSpeed { get; init; }
    public float AttackSpeedPerLevel { get; init; }
    public required bool AutoBanned { get; init; }
    public required string GodCardUrl { get; init; }
    public required string GodIconUrl { get; init; }
    public required float Hp5PerLevel { get; init; }
    public required int Health { get; init; }
    public required int HealthPerFive { get; init; }
    public required int HealthPerLevel { get; init; }
    public required bool LatestGod { get; init; }
    public required string Lore { get; init; }
    public required float Mp5PerLevel { get; init; }
    public required float MagicProtection { get; init; }
    public required float MagicProtectionPerLevel { get; init; }
    public required int MagicalPower { get; init; }
    public required float MagicalPowerPerLevel { get; init; }
    public required int Mana { get; init; }
    public required float ManaPerFive { get; init; }
    public required int ManaPerLevel { get; init; }
    public required string Name { get; init; }
    public required bool OnFreeRotation { get; init; }
    public required string Pantheon { get; init; }
    public required int PhysicalPower { get; init; }
    public required float PhysicalPowerPerLevel { get; init; }
    public required float PhysicalProtection { get; init; }
    public required float PhysicalProtectionPerLevel { get; init; }
    public required string Pros { get; init; }
    public required GodRole Role { get; init; }
    public required int Speed { get; init; }
    public required string Title { get; init; }
    public required GodType Type { get; init; }
    public IEnumerable<CreateGodBasicAttackDto> GodBasicAttackDto { get; init; } = new List<CreateGodBasicAttackDto>();
}
