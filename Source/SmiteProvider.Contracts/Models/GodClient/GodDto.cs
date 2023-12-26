namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

public record class GodDto
{
    public required string Ability1 { get; init; }
    public required string Ability2 { get; init; }
    public required string Ability3 { get; init; }
    public required string Ability4 { get; init; }
    public required string Ability5 { get; init; }
    public required int AbilityId1 { get; init; }
    public required int AbilityId2 { get; init; }
    public required int AbilityId3 { get; init; }
    public required int AbilityId4 { get; init; }
    public required int AbilityId5 { get; init; }
    public required AbilityDetailsDto AbilityDetails1 { get; init; }
    public required AbilityDetailsDto AbilityDetails2 { get; init; }
    public required AbilityDetailsDto AbilityDetails3 { get; init; }
    public required AbilityDetailsDto AbilityDetails4 { get; init; }
    public required AbilityDetailsDto AbilityDetails5 { get; init; }
    public required float AttackSpeed { get; init; }
    public required float AttackSpeedPerLevel { get; init; }
    public required string AutoBanned { get; init; }
    public required string Cons { get; init; }
    public required float Hp5PerLevel { get; init; }
    public required int Health { get; init; }
    public required int HealthPerFive { get; init; }
    public required int HealthPerLevel { get; init; }
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
    public required string OnFreeRotation { get; init; }
    public required string Pantheon { get; init; }
    public required int PhysicalPower { get; init; }
    public required float PhysicalPowerPerLevel { get; init; }
    public required float PhysicalProtection { get; init; }
    public required float PhysicalProtectionPerLevel { get; init; }
    public required string Pros { get; init; }
    public required string Roles { get; init; }
    public required int Speed { get; init; }
    public required string Title { get; init; }
    public required string Type { get; init; }
    public required AbilityDescriptionDto AbilityDescription1 { get; init; }
    public required AbilityDescriptionDto AbilityDescription2 { get; init; }
    public required AbilityDescriptionDto AbilityDescription3 { get; init; }
    public required AbilityDescriptionDto AbilityDescription4 { get; init; }
    public required AbilityDescriptionDto AbilityDescription5 { get; init; }
    public required GodBasicAttackDto GodBasicAttack { get; init; }
    public required string GodAbility1Url { get; init; }
    public required string GodAbility2Url { get; init; }
    public required string GodAbility3Url { get; init; }
    public required string GodAbility4Url { get; init; }
    public required string GodAbility5Url { get; init; }
    public required string GodCardUrl { get; init; }
    public required string GodIconUrl { get; init; }
    public required int Id { get; init; }
    public required string LatestGod { get; init; }
    public string? RetMsg { get; init; }
}
