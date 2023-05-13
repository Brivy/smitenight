namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient
{
    public record class GodDto(
        string Ability1,
        string Ability2,
        string Ability3,
        string Ability4,
        string Ability5,
        int AbilityId1,
        int AbilityId2,
        int AbilityId3,
        int AbilityId4,
        int AbilityId5,
        AbilityDetailsDto AbilityDetails1,
        AbilityDetailsDto AbilityDetails2,
        AbilityDetailsDto AbilityDetails3,
        AbilityDetailsDto AbilityDetails4,
        AbilityDetailsDto AbilityDetails5,
        float AttackSpeed,
        float AttackSpeedPerLevel,
        string AutoBanned,
        string Cons,
        float Hp5PerLevel,
        int Health,
        int HealthPerFive,
        int HealthPerLevel,
        string Lore,
        float Mp5PerLevel,
        float MagicProtection,
        float MagicProtectionPerLevel,
        int MagicalPower,
        float MagicalPowerPerLevel,
        int Mana,
        float ManaPerFive,
        int ManaPerLevel,
        string Name,
        string OnFreeRotation,
        string Pantheon,
        int PhysicalPower,
        float PhysicalPowerPerLevel,
        float PhysicalProtection,
        float PhysicalProtectionPerLevel,
        string Pros,
        string Roles,
        int Speed,
        string Title,
        string Type,
        AbilityDescriptionDto AbilityDescription1,
        AbilityDescriptionDto AbilityDescription2,
        AbilityDescriptionDto AbilityDescription3,
        AbilityDescriptionDto AbilityDescription4,
        AbilityDescriptionDto AbilityDescription5,
        BasicAttackDto BasicAttack,
        string GodAbility1Url,
        string GodAbility2Url,
        string GodAbility3Url,
        string GodAbility4Url,
        string GodAbility5Url,
        string GodCardUrl,
        string GodIconUrl,
        int Id,
        string LatestGod,
        object RetMsg
     );

    public record class AbilityDetailsDto(
        DescriptionDto Description,
        int Id,
        string Summary,
        string Url
     );

    public record class DescriptionDto(
        ItemDescriptionDto ItemDescription
     );

    public record class ItemDescriptionDto(
        string Cooldown,
        string Cost,
        string Description,
        MenuItemDto[] MenuItems,
        RankItemDto[] RankItems
     );

    public record class MenuItemDto(
        string Description,
        string Value
     );

    public record class RankItemDto(
        string Description,
        string Value
     );

    public record class AbilityDescriptionDto
    (
        ItemDescriptionDto ItemDescription
    );

    public record class BasicAttackDto
    (
        BasicAttackDescriptionDto ItemDescription
    );

    public record class BasicAttackDescriptionDto
    (
        string Cooldown,
        string Cost,
        string Description,
        BasicAttackItemDto[] MenuItems,
        RankItemDto[] RankItems
    );

    public record class BasicAttackItemDto(
        string Description,
        string Value
    );
}
