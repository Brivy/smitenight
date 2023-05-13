using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient
{
    public record class God
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
        [JsonPropertyName("Ability_1")] public AbilityDetails? AbilityDetails1 { get; set; }
        [JsonPropertyName("Ability_2")] public AbilityDetails? AbilityDetails2 { get; set; }
        [JsonPropertyName("Ability_3")] public AbilityDetails? AbilityDetails3 { get; set; }
        [JsonPropertyName("Ability_4")] public AbilityDetails? AbilityDetails4 { get; set; }
        [JsonPropertyName("Ability_5")] public AbilityDetails? AbilityDetails5 { get; set; }
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
        [JsonPropertyName("MagicProtection")] public float MagicProtection { get; set; }
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
        [JsonPropertyName("PhysicalProtection")] public float PhysicalProtection { get; set; }
        [JsonPropertyName("PhysicalProtectionPerLevel")] public float PhysicalProtectionPerLevel { get; set; }
        [JsonPropertyName("Pros")] public string? Pros { get; set; }
        [JsonPropertyName("Roles")] public string? Roles { get; set; }
        [JsonPropertyName("Speed")] public int Speed { get; set; }
        [JsonPropertyName("Title")] public string? Title { get; set; }
        [JsonPropertyName("Type")] public string? Type { get; set; }
        [JsonPropertyName("abilityDescription1")] public AbilityDescription? AbilityDescription1 { get; set; }
        [JsonPropertyName("abilityDescription2")] public AbilityDescription? AbilityDescription2 { get; set; }
        [JsonPropertyName("abilityDescription3")] public AbilityDescription? AbilityDescription3 { get; set; }
        [JsonPropertyName("abilityDescription4")] public AbilityDescription? AbilityDescription4 { get; set; }
        [JsonPropertyName("abilityDescription5")] public AbilityDescription? AbilityDescription5 { get; set; }
        [JsonPropertyName("basicAttack")] public BasicAttack? BasicAttack { get; set; }
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

    public record class AbilityDetails
    {
        [JsonPropertyName("Description")] public Description? Description { get; set; }
        [JsonPropertyName("Id")] public int Id { get; set; }
        [JsonPropertyName("Summary")] public string? Summary { get; set; }
        [JsonPropertyName("URL")] public string? Url { get; set; }
    }

    public record class Description
    {
        [JsonPropertyName("itemDescription")] public ItemDescription? ItemDescription { get; set; }
    }

    public record class ItemDescription
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public MenuItem[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem[]? RankItems { get; set; }
    }

    public record class MenuItem
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class RankItem
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }

    public record class AbilityDescription
    {
        [JsonPropertyName("itemDescription")] public ItemDescription? ItemDescription { get; set; }
    }

    public record class BasicAttack
    {
        [JsonPropertyName("itemDescription")] public ItemDescription? ItemDescription { get; set; }
    }

    public record class BasicAttackDescription
    {
        [JsonPropertyName("cooldown")] public string? Cooldown { get; set; }
        [JsonPropertyName("cost")] public string? Cost { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("menuitems")] public BasicAttackItem[]? MenuItems { get; set; }
        [JsonPropertyName("rankitems")] public RankItem[]? RankItems { get; set; }
    }

    public record class BasicAttackItem
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }
}
