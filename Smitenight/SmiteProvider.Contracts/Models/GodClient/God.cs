namespace Smitenight.Domain.Models.Clients.GodClient
{
    public record class God(
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
        AbilityDetails1 AbilityDetails1,
        AbilityDetails2 AbilityDetails2,
        AbilityDetails3 AbilityDetails3,
        AbilityDetails4 AbilityDetails4,
        AbilityDetails5 AbilityDetails5,
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
        AbilityDescription1 AbilityDescription1,
        AbilityDescription2 AbilityDescription2,
        AbilityDescription3 AbilityDescription3,
        AbilityDescription4 AbilityDescription4,
        AbilityDescription5 AbilityDescription5,
        BasicAttack BasicAttack,
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

    public record class AbilityDetails1(
        Description Description,
        int Id,
        string Summary,
        string Url
     );

    public record class Description(
        ItemDescription ItemDescription
     );

    public record class ItemDescription(
        string Cooldown,
        string Cost,
        string Description,
        MenuItem[] MenuItems,
        RankItem[] RankItems
     );

    public record class MenuItem(
        string Description,
        string Value
     );

    public record class RankItem(
        string Description,
        string Value
     );

    public record class AbilityDetails2(
        Description1 Description,
        int Id,
        string Summary,
        string Url
    );

    public record class Description1(
        ItemDescription1 ItemDescription
    );

    public record class ItemDescription1(
        string Cooldown,
        string Cost,
        string Description,
        MenuItem1[] MenuItems,
        RankItem1[] RankItems
    );

    public record class MenuItem1(
        string Description,
        string Value
    );

    public record class RankItem1(
        string Description,
        string Value
    );

    public record class AbilityDetails3(
        Description2 Description,
        int Id,
        string Summary,
        string Url
    );

    public record class Description2(
        ItemDescription2 ItemDescription
    );

    public record class ItemDescription2(
        string Cooldown,
        string Cost,
        string Description,
        MenuItem2[] MenuItems,
        RankItem2[] RankItems
    );

    public record class MenuItem2(
        string Description,
        string Value
    );

    public record class RankItem2(
        string Description,
        string Value
    );

    public record class AbilityDetails4
    (
        Description3 Description,
        int Id,
        string Summary,
        string Url
    );

    public record class Description3
    (
        ItemDescription3 ItemDescription
    );

    public record class ItemDescription3
    (
        string Cooldown,
        string Cost,
        string Description,
        MenuItem3[] MenuItems,
        RankItem3[] RankItems
    );

    public record class MenuItem3
    (
        string Description,
        string Value
    );

    public record class RankItem3
    (
        string Description,
        string Value
    );

    public record class AbilityDetails5
    (
        Description4 Description,
        int Id,
        string Summary,
        string Url
    );

    public record class Description4
    (
        ItemDescription4 ItemDescription
    );

    public record class ItemDescription4
    (
        string Cooldown,
        string Cost,
        string Description,
        MenuItem4[] MenuItems,
        RankItem4[] RankItems
    );

    public record class MenuItem4
    (
        string Description,
        string Value
    );

    public record class RankItem4
    (
        string Description,
        string Value
    );

    public record class AbilityDescription1
    (
        ItemDescription5 ItemDescription
    );

    public record class ItemDescription5
     (
        string Cooldown,
        string Cost,
        string Description,
        MenuItem5[] MenuItems,
        RankItem5[] RankItems
    );

    public record class MenuItem5
    (
        string Description,
        string Value
    );

    public record class RankItem5
    (
        string Description,
        string Value
    );

    public record class AbilityDescription2
    (
        ItemDescription6 ItemDescription
    );

    public record class ItemDescription6
    (
        string Cooldown,
        string Cost,
        string Description,
        MenuItem6[] MenuItems,
        RankItem6[] RankItems
    );

    public record class MenuItem6
    (
        string Description,
        string Value
    );

    public record class RankItem6
    (
        string Description,
        string Value
    );

    public record class AbilityDescription3
    (
        ItemDescription7 ItemDescription
    );

    public record class ItemDescription7
    (
        string Cooldown,
        string Cost,
        string Description,
        MenuItem7[] MenuItems,
        RankItem7[] RankItems
    );

    public record class MenuItem7
    (
        string Description,
        string Value
    );

    public record class RankItem7
    (
        string Description,
        string Value
    );

    public record class AbilityDescription4
    (
        ItemDescription8 ItemDescription
    );

    public record class ItemDescription8
    (
        string Cooldown,
        string Cost,
        string Description,
        MenuItem8[] MenuItems,
        RankItem8[] RankItems
    );

    public record class MenuItem8
    (
        string Description,
        string Value
    );

    public record class RankItem8
    (
        string Description,
        string Value
    );

    public record class AbilityDescription5
    (
        ItemDescription9 ItemDescription
    );

    public record class ItemDescription9
    (
        string Cooldown,
        string Cost,
        string Description,
        MenuItem9[] MenuItems,
        RankItem9[] RankItems
    );

    public record class MenuItem9
    (
        string Description,
        string Value
    );

    public record class RankItem9
    (
        string Description,
        string Value
    );

    public record class BasicAttack
    (
        ItemDescription10 ItemDescription
    );

    public record class ItemDescription10
    (
        string Cooldown,
        string Cost,
        string Description,
        MenuItem10[] MenuItems,
        object[] RankItems
    );

    public record class MenuItem10
    (
        string Description,
        string Value
    );
}
