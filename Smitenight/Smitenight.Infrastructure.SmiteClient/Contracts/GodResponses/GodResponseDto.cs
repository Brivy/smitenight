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
        [property: JsonPropertyName("Ability_1")] AbilityDetails1Dto AbilityDetails1,
        [property: JsonPropertyName("Ability_2")] AbilityDetails2Dto AbilityDetails2,
        [property: JsonPropertyName("Ability_3")] AbilityDetails3Dto AbilityDetails3,
        [property: JsonPropertyName("Ability_4")] AbilityDetails4Dto AbilityDetails4,
        [property: JsonPropertyName("Ability_5")] AbilityDetails5Dto AbilityDetails5,
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
        [property: JsonPropertyName("MagicalPowerPerLevel")] float MagicalPowerPerLevel,
        [property: JsonPropertyName("Mana")] int Mana,
        [property: JsonPropertyName("ManaPerFive")] float ManaPerFive,
        [property: JsonPropertyName("ManaPerLevel")] int ManaPerLevel,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("OnFreeRotation")] string OnFreeRotation,
        [property: JsonPropertyName("Pantheon")] string Pantheon,
        [property: JsonPropertyName("PhysicalPower")] int PhysicalPower,
        [property: JsonPropertyName("PhysicalPowerPerLevel")] float PhysicalPowerPerLevel,
        [property: JsonPropertyName("PhysicalProtection")] int PhysicalProtection,
        [property: JsonPropertyName("PhysicalProtectionPerLevel")] float PhysicalProtectionPerLevel,
        [property: JsonPropertyName("Pros")] string Pros,
        [property: JsonPropertyName("Roles")] string Roles,
        [property: JsonPropertyName("Speed")] int Speed,
        [property: JsonPropertyName("Title")] string Title,
        [property: JsonPropertyName("Type")] string Type,
        [property: JsonPropertyName("abilityDescription1")] AbilityDescription1Dto AbilityDescription1,
        [property: JsonPropertyName("abilityDescription2")] AbilityDescription2Dto AbilityDescription2,
        [property: JsonPropertyName("abilityDescription3")] AbilityDescription3Dto AbilityDescription3,
        [property: JsonPropertyName("abilityDescription4")] AbilityDescription4Dto AbilityDescription4,
        [property: JsonPropertyName("abilityDescription5")] AbilityDescription5Dto AbilityDescription5,
        [property: JsonPropertyName("basicAttack")] BasicAttackDto BasicAttack,
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

    public record class AbilityDetails1Dto(
        [property: JsonPropertyName("Description")] DescriptionDto Description,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Summary")] string Summary,
        [property: JsonPropertyName("URL")] string Url
     );

    public record class DescriptionDto(
        [property: JsonPropertyName("itemDescription")] ItemDescriptionDto ItemDescription
     );

    public record class ItemDescriptionDto(
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItemDto[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItemDto[] RankItems
     );

    public record class MenuItemDto(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
     );

    public record class RankItemDto(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
     );

    public record class AbilityDetails2Dto(
        [property: JsonPropertyName("Description")] Description1Dto Description,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Summary")] string Summary,
        [property: JsonPropertyName("URL")] string Url
    );

    public record class Description1Dto(
        [property: JsonPropertyName("itemDescription")] ItemDescription1Dto ItemDescription
    );

    public record class ItemDescription1Dto(
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem1Dto[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem1Dto[] RankItems
    );

    public record class MenuItem1Dto(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem1Dto(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDetails3Dto(
        [property: JsonPropertyName("Description")] Description2Dto Description,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Summary")] string Summary,
        [property: JsonPropertyName("URL")] string Url
    );

    public record class Description2Dto(
        [property: JsonPropertyName("itemDescription")] ItemDescription2Dto ItemDescription
    );

    public record class ItemDescription2Dto(
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem2Dto[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem2Dto[] RankItems
    );

    public record class MenuItem2Dto(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem2Dto(
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDetails4Dto
    (
        [property: JsonPropertyName("Description")] Description3Dto Description,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Summary")] string Summary,
        [property: JsonPropertyName("URL")] string Url
    );

    public record class Description3Dto
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription3Dto ItemDescription
    );

    public record class ItemDescription3Dto
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem3Dto[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem3Dto[] RankItems
    );

    public record class MenuItem3Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem3Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDetails5Dto
    (
        [property: JsonPropertyName("Description")] Description4Dto Description,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Summary")] string Summary,
        [property: JsonPropertyName("URL")] string Url
    );

    public record class Description4Dto
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription4Dto ItemDescription
    );

    public record class ItemDescription4Dto
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem4Dto[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem4Dto[] RankItems
    );

    public record class MenuItem4Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem4Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDescription1Dto
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription5Dto ItemDescription
    );

    public record class ItemDescription5Dto
     (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem5Dto[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem5Dto[] RankItems
    );

    public record class MenuItem5Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem5Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDescription2Dto
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription6Dto ItemDescription
    );

    public record class ItemDescription6Dto
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem6Dto[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem6Dto[] RankItems
    );

    public record class MenuItem6Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem6Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDescription3Dto
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription7Dto ItemDescription
    );

    public record class ItemDescription7Dto
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem7Dto[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem7Dto[] RankItems
    );

    public record class MenuItem7Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem7Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDescription4Dto
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription8Dto ItemDescription
    );

    public record class ItemDescription8Dto
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem8Dto[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem8Dto[] RankItems
    );

    public record class MenuItem8Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem8Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class AbilityDescription5Dto
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription9Dto ItemDescription
    );

    public record class ItemDescription9Dto
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem9Dto[] MenuItems,
        [property: JsonPropertyName("rankitems")] RankItem9Dto[] RankItems
    );

    public record class MenuItem9Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class RankItem9Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );

    public record class BasicAttackDto
    (
        [property: JsonPropertyName("itemDescription")] ItemDescription10Dto ItemDescription
    );

    public record class ItemDescription10Dto
    (
        [property: JsonPropertyName("cooldown")] string Cooldown,
        [property: JsonPropertyName("cost")] string Cost,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("menuitems")] MenuItem10Dto[] MenuItems,
        [property: JsonPropertyName("rankitems")] object[] RankItems
    );

    public record class MenuItem10Dto
    (
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("value")] string Value
    );
}
