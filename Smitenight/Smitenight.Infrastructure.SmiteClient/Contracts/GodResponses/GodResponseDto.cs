using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.GodResponses
{
    public record class GodResponseDto
    {
        [JsonPropertyName("Ability1")] public string? Ability1 { get; set; }
        [JsonPropertyName("Ability2")] public string? Ability2 { get; set; }
        [JsonPropertyName("Ability3")] public string? Ability3 { get; set; }
        [JsonPropertyName("Ability4")] public string? Ability4 { get; set; }
        [JsonPropertyName("Ability5")] public string? Ability5 { get; set; }
        [JsonPropertyName("AbilityId1")] public int AbilityId1 { get; set; }
        [JsonPropertyName("AbilityId2")] public int AbilityId2 { get; set; }
        [JsonPropertyName("AbilityId3")] public int AbilityId3 { get; set; }
        [JsonPropertyName("AbilityId4")] public int AbilityId4 { get; set; }
        [JsonPropertyName("AbilityId5")] public int AbilityId5 { get; set; }
        [JsonPropertyName("Ability_1")] public AbilityDetails1Dto? AbilityDetails1 { get; set; }
        [JsonPropertyName("Ability_2")] public AbilityDetails2Dto? AbilityDetails2 { get; set; }
        [JsonPropertyName("Ability_3")] public AbilityDetails3Dto? AbilityDetails3 { get; set; }
        [JsonPropertyName("Ability_4")] public AbilityDetails4Dto? AbilityDetails4 { get; set; }
        [JsonPropertyName("Ability_5")] public AbilityDetails5Dto? AbilityDetails5 { get; set; }
        [JsonPropertyName("AttackSpeed")] public float AttackSpeed { get; set; }
        [JsonPropertyName("AttackSpeedPerLevel")] public float AttackSpeedPerLevel { get; set; }
        [JsonPropertyName("AutoBanned")] public string? AutoBanned { get; set; }
        [JsonPropertyName("Cons")] public string? Cons { get; set; }
        [JsonPropertyName("HP5PerLevel")] public float Hp5PerLevel { get; set; }
        [JsonPropertyName("Health")] public int Health { get; set; }
        [JsonPropertyName("HealthPerFive")] public int HealthPerFive { get; set; }
        [JsonPropertyName("HealthPerLevel")] public int HealthPerLevel { get; set; }
        [JsonPropertyName("Lore")] public string? Lore { get; set; }
        [JsonPropertyName("MP5PerLevel")] public float Mp5PerLevel { get; set; }
        [JsonPropertyName("MagicProtection")] public int MagicProtection { get; set; }
        [JsonPropertyName("MagicProtectionPerLevel")] public float MagicProtectionPerLevel { get; set; }
        [JsonPropertyName("MagicalPower")] public int MagicalPower { get; set; }
        [JsonPropertyName("MagicalPowerPerLevel")] public float MagicalPowerPerLevel { get; set; }
        [JsonPropertyName("Mana")] public int Mana { get; set; }
        [JsonPropertyName("ManaPerFive")] public float ManaPerFive { get; set; }
        [JsonPropertyName("ManaPerLevel")] public int ManaPerLevel { get; set; }
        [JsonPropertyName("Name")] public string? Name { get; set; }
        [JsonPropertyName("OnFreeRotation")] public string? OnFreeRotation { get; set; }
        [JsonPropertyName("Pantheon")] public string? Pantheon { get; set; }
        [JsonPropertyName("PhysicalPower")] public int PhysicalPower { get; set; }
        [JsonPropertyName("PhysicalPowerPerLevel")] public float PhysicalPowerPerLevel { get; set; }
        [JsonPropertyName("PhysicalProtection")] public int PhysicalProtection { get; set; }
        [JsonPropertyName("PhysicalProtectionPerLevel")] public float PhysicalProtectionPerLevel { get; set; }
        [JsonPropertyName("Pros")] public string? Pros { get; set; }
        [JsonPropertyName("Roles")] public string? Roles { get; set; }
        [JsonPropertyName("Speed")] public int Speed { get; set; }
        [JsonPropertyName("Title")] public string? Title { get; set; }
        [JsonPropertyName("Type")] public string? Type { get; set; }
        [JsonPropertyName("abilityDescription1")] public AbilityDescription1Dto? AbilityDescription1 { get; set; }
        [JsonPropertyName("abilityDescription2")] public AbilityDescription2Dto? AbilityDescription2 { get; set; }
        [JsonPropertyName("abilityDescription3")] public AbilityDescription3Dto? AbilityDescription3 { get; set; }
        [JsonPropertyName("abilityDescription4")] public AbilityDescription4Dto? AbilityDescription4 { get; set; }
        [JsonPropertyName("abilityDescription5")] public AbilityDescription5Dto? AbilityDescription5 { get; set; }
        [JsonPropertyName("basicAttack")] public BasicAttackDto? BasicAttack { get; set; }
        [JsonPropertyName("godAbility1_URL")] public string? GodAbility1Url { get; set; }
        [JsonPropertyName("godAbility2_URL")] public string? GodAbility2Url { get; set; }
        [JsonPropertyName("godAbility3_URL")] public string? GodAbility3Url { get; set; }
        [JsonPropertyName("godAbility4_URL")] public string? GodAbility4Url { get; set; }
        [JsonPropertyName("godAbility5_URL")] public string? GodAbility5Url { get; set; }
        [JsonPropertyName("godCard_URL")] public string? GodCardUrl { get; set; }
        [JsonPropertyName("godIcon_URL")] public string? GodIconUrl { get; set; }
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("latestGod")] public string? LatestGod { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }

    public record class AbilityDetails1Dto
    { 
        [JsonPropertyName("Description")] public DescriptionDto? Description { get; set; }
        [JsonPropertyName("Id")] public int Id { get; set; }
        [JsonPropertyName("Summary")] public string? Summary { get; set; }
        [JsonPropertyName("URL")] public string? Url { get; set; }
    }

    public record class DescriptionDto
    {
        [JsonPropertyName("itemDescription")] public ItemDescriptionDto? ItemDescription { get; set; }
    }

    public record class ItemDescriptionDto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItemDto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItemDto[]? RankItems { get; set; }
    }

    public record class MenuItemDto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItemDto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class AbilityDetails2Dto
    {
        [JsonPropertyName("Description")] public Description1Dto? Description { get; set; }
        [JsonPropertyName("Id")] public int Id { get; set; }
        [JsonPropertyName("Summary")] public string? Summary { get; set; }
        [JsonPropertyName("URL")] public string? Url { get; set; }
    }

    public record class Description1Dto
    {
        [JsonPropertyName("itemDescription")] public ItemDescription1Dto? ItemDescription { get; set; }
    }

    public record class ItemDescription1Dto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem1Dto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem1Dto[]? RankItems { get; set; }
    }

    public record class MenuItem1Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItem1Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class AbilityDetails3Dto
    {
        [JsonPropertyName("Description")] public Description2Dto? Description { get; set; }
        [JsonPropertyName("Id")] public int Id { get; set; }
        [JsonPropertyName("Summary")] public string? Summary { get; set; }
        [JsonPropertyName("URL")] public string? Url { get; set; }
    }

    public record class Description2Dto
    {
        [JsonPropertyName("itemDescription")] public ItemDescription2Dto? ItemDescription { get; set; }
    }

    public record class ItemDescription2Dto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem2Dto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem2Dto[]? RankItems { get; set; }
    }

    public record class MenuItem2Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItem2Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class AbilityDetails4Dto
    {
        [JsonPropertyName("Description")] public Description3Dto? Description { get; set; }
        [JsonPropertyName("Id")] public int Id { get; set; }
        [JsonPropertyName("Summary")] public string? Summary { get; set; }
        [JsonPropertyName("URL")] public string? Url { get; set; }
    }

    public record class Description3Dto
    {
        [JsonPropertyName("itemDescription")] public ItemDescription3Dto? ItemDescription { get; set; }
    }

    public record class ItemDescription3Dto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem3Dto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem3Dto[]? RankItems { get; set; }
    }

    public record class MenuItem3Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItem3Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class AbilityDetails5Dto
    {
        [JsonPropertyName("Description")] public Description4Dto? Description { get; set; }
        [JsonPropertyName("Id")] public int Id { get; set; }
        [JsonPropertyName("Summary")] public string? Summary { get; set; }
        [JsonPropertyName("URL")] public string? Url { get; set; }
    }

    public record class Description4Dto
    {
        [JsonPropertyName("itemDescription")] public ItemDescription4Dto? ItemDescription { get; set; }
    }

    public record class ItemDescription4Dto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem4Dto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem4Dto[]? RankItems { get; set; }
    }

    public record class MenuItem4Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItem4Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class AbilityDescription1Dto
    {
        [JsonPropertyName("itemDescription")] public ItemDescription5Dto? ItemDescription { get; set; }
    }

    public record class ItemDescription5Dto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem5Dto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem5Dto[]? RankItems { get; set; }
    }

    public record class MenuItem5Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItem5Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class AbilityDescription2Dto
    {
        [JsonPropertyName("itemDescription")] public ItemDescription6Dto? ItemDescription { get; set; }
    }

    public record class ItemDescription6Dto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem6Dto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem6Dto[]? RankItems { get; set; }
    }

    public record class MenuItem6Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItem6Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class AbilityDescription3Dto
    {
        [JsonPropertyName("itemDescription")] public ItemDescription7Dto? ItemDescription { get; set; }
    }

    public record class ItemDescription7Dto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem7Dto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem7Dto[]? RankItems { get; set; }
    }

    public record class MenuItem7Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItem7Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class AbilityDescription4Dto
    {
        [JsonPropertyName("itemDescription")] public ItemDescription8Dto? ItemDescription { get; set; }
    }

    public record class ItemDescription8Dto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem8Dto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem8Dto[]? RankItems { get; set; }
    }

    public record class MenuItem8Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItem8Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class AbilityDescription5Dto
    {
        [JsonPropertyName("itemDescription")] public ItemDescription9Dto? ItemDescription { get; set; }
    }

    public record class ItemDescription9Dto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem9Dto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem9Dto[]? RankItems { get; set; }
    }

    public record class MenuItem9Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItem9Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class BasicAttackDto
    {
        [JsonPropertyName("itemDescription")] public ItemDescription10Dto? ItemDescription { get; set; }
    }

    public record class ItemDescription10Dto
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem10Dto[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public object[]? RankItems { get; set; }
    }

    public record class MenuItem10Dto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }
}
