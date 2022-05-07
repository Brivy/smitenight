using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.GodResponses
{
    public record class GodResponseDto(
        [property: JsonPropertyName("Ability1")] string Ability1,
        [property: JsonPropertyName("Ability2")] string Ability2,
        [property: JsonPropertyName("Ability3")] string Ability3,
        [property: JsonPropertyName("Ability4")] string Ability4,
        [property: JsonPropertyName("Ability5")] string Ability5,
        [property: JsonPropertyName("AbilityId1")] int AbilityId1,
        [property: JsonPropertyName("AbilityId2")] int AbilityId2,
        [property: JsonPropertyName("AbilityId3")] int AbilityId3,
        [property: JsonPropertyName("AbilityId4")] int AbilityId4,
        [property: JsonPropertyName("AbilityId5")] int AbilityId5,
        [property: JsonPropertyName("Ability_1")] AbilityDetails1 AbilityDetails1,
        [property: JsonPropertyName("Ability_2")] AbilityDetails2 AbilityDetails2,
        [property: JsonPropertyName("Ability_3")] AbilityDetails3 AbilityDetails3,
        [property: JsonPropertyName("Ability_4")] AbilityDetails4 AbilityDetails4,
        [property: JsonPropertyName("Ability_5")] AbilityDetails5 AbilityDetails5,
        [property: JsonPropertyName("AttackSpeed")] float AttackSpeed,
        [property: JsonPropertyName("AttackSpeedPerLevel")] float AttackSpeedPerLevel,
        [property: JsonPropertyName("AutoBanned")] string AutoBanned,
        [property: JsonPropertyName("Cons")] string Cons,
        [property: JsonPropertyName("HP5PerLevel")] float Hp5PerLevel,
        [property: JsonPropertyName("Health")] int Health,
        [property: JsonPropertyName("HealthPerFive")] int HealthPerFive,
        [property: JsonPropertyName("HealthPerLevel")] int HealthPerLevel,
        [property: JsonPropertyName("Lore")] string Lore,
        [property: JsonPropertyName("MP5PerLevel")] float Mp5PerLevel,
        [property: JsonPropertyName("MagicProtection")] int MagicProtection,
        [property: JsonPropertyName("MagicProtectionPerLevel")] float MagicProtectionPerLevel,
        [property: JsonPropertyName("MagicalPower")] int MagicalPower,
        [property: JsonPropertyName("MagicalPowerPerLevel")] int MagicalPowerPerLevel,
        [property: JsonPropertyName("Mana")] int Mana,
        [property: JsonPropertyName("ManaPerFive")] float ManaPerFive,
        [property: JsonPropertyName("ManaPerLevel")] int ManaPerLevel,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("OnFreeRotation")] string OnFreeRotation,
        [property: JsonPropertyName("Pantheon")] string Pantheon,
        [property: JsonPropertyName("PhysicalPower")] int PhysicalPower,
        [property: JsonPropertyName("PhysicalPowerPerLevel")] int PhysicalPowerPerLevel,
        [property: JsonPropertyName("PhysicalProtection")] int PhysicalProtection,
        [property: JsonPropertyName("PhysicalProtectionPerLevel")] int PhysicalProtectionPerLevel,
        [property: JsonPropertyName("Pros")] string Pros,
        [property: JsonPropertyName("Roles")] string Roles,
        [property: JsonPropertyName("Speed")] int Speed,
        [property: JsonPropertyName("Title")] string Title,
        [property: JsonPropertyName("Type")] string Type,
        [property: JsonPropertyName("abilityDescription1")] AbilityDescription1 AbilityDescription1,
        [property: JsonPropertyName("abilityDescription2")] AbilityDescription2 AbilityDescription2,
        [property: JsonPropertyName("abilityDescription3")] AbilityDescription3 AbilityDescription3,
        [property: JsonPropertyName("abilityDescription4")] AbilityDescription4 AbilityDescription4,
        [property: JsonPropertyName("abilityDescription5")] AbilityDescription5 AbilityDescription5,
        [property: JsonPropertyName("basicAttack")] BasicAttack BasicAttack,
        [property: JsonPropertyName("godAbility1_URL")] string GodAbility1Url,
        [property: JsonPropertyName("godAbility2_URL")] string GodAbility2Url,
        [property: JsonPropertyName("godAbility3_URL")] string GodAbility3Url,
        [property: JsonPropertyName("godAbility4_URL")] string GodAbility4Url,
        [property: JsonPropertyName("godAbility5_URL")] string GodAbility5Url,
        [property: JsonPropertyName("godCard_URL")] string GodCardUrl,
        [property: JsonPropertyName("godIcon_URL")] string GodIconUrl,
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("latestGod")] string LatestGod,
        [property: JsonPropertyName("ret_msg")] object RetMsg
     );

    public record class AbilityDetails1(
        [property: JsonPropertyName("Description")] Description Description,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Summary")] string Summary,
        [property: JsonPropertyName("URL")] string Url
     );

    public record class Description(
        [property: JsonPropertyName("itemDescription")] ItemDescription ItemDescription
     );

    public record class ItemDescription(
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem[] RankItems
     );

    public record class MenuItem(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
     );

    public record class RankItem(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
     );

    public record class AbilityDetails2(
        [property: JsonPropertyName("Description")] Description1 Description,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Summary")] string Summary,
        [property: JsonPropertyName("URL")] string Url
    );

    public record class Description1(
        [property: JsonPropertyName("itemDescription")] ItemDescription1 ItemDescription
    );

    public record class ItemDescription1(
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem1[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem1[] RankItems
    );

    public record class MenuItem1(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem1(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDetails3(
        [property: JsonPropertyName("Description")] Description2 Description,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Summary")] string Summary,
        [property: JsonPropertyName("URL")] string Url
    );

    public record class Description2(
        [property: JsonPropertyName("itemDescription")] ItemDescription2 ItemDescription
    );

    public record class ItemDescription2(
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem2[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem2[] RankItems
    );

    public record class MenuItem2(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem2(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDetails4
    (
        [property: JsonPropertyName("Description")] Description3 Description,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Summary")] string Summary,
        [property: JsonPropertyName("URL")] string Url
    );

    public record class Description3
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription3 ItemDescription
    );

    public record class ItemDescription3
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem3[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem3[] RankItems
    );

    public record class MenuItem3
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem3
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDetails5
    (
        [property: JsonPropertyName("Description")] Description4 Description,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Summary")] string Summary,
        [property: JsonPropertyName("URL")] string Url
    );

    public record class Description4
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription4 ItemDescription
    );

    public record class ItemDescription4
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem4[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem4[] RankItems
    );

    public record class MenuItem4
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem4
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDescription1
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription5 ItemDescription
    );

    public record class ItemDescription5
     (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem5[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem5[] RankItems
    );

    public record class MenuItem5
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem5
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDescription2
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription6 ItemDescription
    );

    public record class ItemDescription6
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem6[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem6[] RankItems
    );

    public record class MenuItem6
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem6
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDescription3
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription7 ItemDescription
    );

    public record class ItemDescription7
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem7[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem7[] RankOtems
    );

    public record class MenuItem7
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem7
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDescription4
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription8 ItemDescription
    );

    public record class ItemDescription8
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem8[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem8[] RankItems
    );

    public record class MenuItem8
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem8
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDescription5
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription9 ItemDescription
    );

    public record class ItemDescription9
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem9[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem9[] RankItems
    );

    public record class MenuItem9
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem9
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class BasicAttack
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription10 ItemDescription
    );

    public record class ItemDescription10
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem10[] MenuItems,
        [property: JsonPropertyName("rankitems")] object[] RankItems
    );

    public record class MenuItem10
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );
}
