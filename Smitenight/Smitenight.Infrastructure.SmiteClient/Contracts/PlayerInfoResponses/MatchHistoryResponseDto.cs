using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.PlayerInfoResponses
{
    /// The ReadFromJsonAsync method doesn't allow for constructors more than 64 parameters so we fix this class it with properties 
    public record class MatchHistoryResponseDto
    {
        [JsonPropertyName("ActiveId1")] 
        public int ActiveId1 { get; init; }
        [JsonPropertyName("ActiveId2")] 
        public int ActiveId2 { get; init; }
        [JsonPropertyName("Active_1")] 
        public string? Active1 { get; init; }
        [JsonPropertyName("Active_2")] 
        public string? Active2 { get; init; }
        [JsonPropertyName("Active_3")] 
        public string? Active3 { get; init; }
        [JsonPropertyName("Assists")] 
        public int Assists { get; init; }
        [JsonPropertyName("Ban1")] 
        public string? Ban1 { get; init; }
        [JsonPropertyName("Ban10")] 
        public string? Ban10 { get; init; }
        [JsonPropertyName("Ban10Id")] 
        public int Ban10Id { get; init; }
        [JsonPropertyName("Ban11")] 
        public string? Ban11 { get; init; }
        [JsonPropertyName("Ban11Id")] 
        public int Ban11Id { get; init; }
        [JsonPropertyName("Ban12")] 
        public string? Ban12 { get; init; }
        [JsonPropertyName("Ban12Id")] 
        public int Ban12Id { get; init; }
        [JsonPropertyName("Ban1Id")] 
        public int Ban1Id { get; init; }
        [JsonPropertyName("Ban2")] 
        public string? Ban2 { get; init; }
        [JsonPropertyName("Ban2Id")] 
        public int Ban2Id { get; init; }
        [JsonPropertyName("Ban3")] 
        public string? Ban3 { get; init; }
        [JsonPropertyName("Ban3Id")] 
        public int Ban3Id { get; init; }
        [JsonPropertyName("Ban4")] 
        public string? Ban4 { get; init; }
        [JsonPropertyName("Ban4Id")] 
        public int Ban4Id { get; init; }
        [JsonPropertyName("Ban5")] 
        public string? Ban5 { get; init; }
        [JsonPropertyName("Ban5Id")] 
        public int Ban5Id { get; init; }
        [JsonPropertyName("Ban6")] 
        public string? Ban6 { get; init; }
        [JsonPropertyName("Ban6Id")] 
        public int Ban6Id { get; init; }
        [JsonPropertyName("Ban7")] 
        public string? Ban7 { get; init; }
        [JsonPropertyName("Ban7Id")] 
        public int Ban7Id { get; init; }
        [JsonPropertyName("Ban8")] 
        public string? Ban8 { get; init; }
        [JsonPropertyName("Ban8Id")] 
        public int Ban8Id { get; init; }
        [JsonPropertyName("Ban9")] 
        public string? Ban9 { get; init; }
        [JsonPropertyName("Ban9Id")] 
        public int Ban9Id { get; init; }
        [JsonPropertyName("Creeps")] 
        public int Creeps { get; init; }
        [JsonPropertyName("Damage")] 
        public int Damage { get; init; }
        [JsonPropertyName("Damage_Bot")] 
        public int DamageBot { get; init; }
        [JsonPropertyName("Damage_Done_In_Hand")] 
        public int DamageDoneInHand { get; init; }
        [JsonPropertyName("Damage_Mitigated")] 
        public int DamageMitigated { get; init; }
        [JsonPropertyName("Damage_Structure")] 
        public int DamageStructure { get; init; }
        [JsonPropertyName("Damage_Taken")] 
        public int DamageTaken { get; init; }
        [JsonPropertyName("Damage_Taken_Magical")] 
        public int DamageTakenMagical { get; init; }
        [JsonPropertyName("Damage_Taken_Physical")] 
        public int DamageTakenPhysical { get; init; }
        [JsonPropertyName("Deaths")] 
        public int Deaths { get; init; }
        [JsonPropertyName("Distance_Traveled")] 
        public int DistanceTraveled { get; init; }
        [JsonPropertyName("First_Ban_Side")] 
        public string? FirstBanSide { get; init; }
        [JsonPropertyName("God")] 
        public string? God { get; init; }
        [JsonPropertyName("GodId")] 
        public int GodId { get; init; }
        [JsonPropertyName("Gold")] 
        public int Gold { get; init; }
        [JsonPropertyName("Healing")] 
        public int Healing { get; init; }
        [JsonPropertyName("Healing_Bot")] 
        public int HealingBot { get; init; }
        [JsonPropertyName("Healing_Player_Self")] 
        public int HealingPlayerSelf { get; init; }
        [JsonPropertyName("ItemId1")] 
        public int ItemId1 { get; init; }
        [JsonPropertyName("ItemId2")] 
        public int ItemId2 { get; init; }
        [JsonPropertyName("ItemId3")] 
        public int ItemId3 { get; init; }
        [JsonPropertyName("ItemId4")] 
        public int ItemId4 { get; init; }
        [JsonPropertyName("ItemId5")] 
        public int ItemId5 { get; init; }
        [JsonPropertyName("ItemId6")] 
        public int ItemId6 { get; init; }
        [JsonPropertyName("Item_1")] 
        public string? Item1 { get; init; }
        [JsonPropertyName("Item_2")] 
        public string? Item2 { get; init; }
        [JsonPropertyName("Item_3")] 
        public string? Item3 { get; init; }
        [JsonPropertyName("Item_4")] 
        public string? Item4 { get; init; }
        [JsonPropertyName("Item_5")] 
        public string? Item5 { get; init; }
        [JsonPropertyName("Item_6")] 
        public string? Item6 { get; init; }
        [JsonPropertyName("Killing_Spree")] 
        public int KillingSpree { get; init; }
        [JsonPropertyName("Kills")] 
        public int Kills { get; init; }
        [JsonPropertyName("Level")] 
        public int Level { get; init; }
        [JsonPropertyName("Map_Game")] 
        public string? MapGame { get; init; }
        [JsonPropertyName("Match")] 
        public int Match { get; init; }
        [JsonPropertyName("Match_Queue_Id")] 
        public int MatchQueueId { get; init; }
        [JsonPropertyName("Match_Time")] 
        public string? MatchTime { get; init; }
        [JsonPropertyName("Minutes")] 
        public int Minutes { get; init; }
        [JsonPropertyName("Multi_kill_Max")] 
        public int MultiKillMax { get; init; }
        [JsonPropertyName("Objective_Assists")] 
        public int ObjectiveAssists { get; init; }
        [JsonPropertyName("Queue")] 
        public string? Queue { get; init; }
        [JsonPropertyName("Region")] 
        public string? Region { get; init; }
        [JsonPropertyName("Role")] 
        public string? Role { get; init; }
        [JsonPropertyName("Skin")] 
        public string? Skin { get; init; }
        [JsonPropertyName("SkinId")] 
        public int SkinId { get; init; }
        [JsonPropertyName("Surrendered")] 
        public int Surrendered { get; init; }
        [JsonPropertyName("TaskForce")] 
        public int TaskForce { get; init; }
        [JsonPropertyName("Team1Score")] 
        public int Team1Score { get; init; }
        [JsonPropertyName("Team2Score")] 
        public int Team2Score { get; init; }
        [JsonPropertyName("Time_In_Match_Seconds")] 
        public int TimeInMatchSeconds { get; init; }
        [JsonPropertyName("Wards_Placed")] 
        public int WardsPlaced { get; init; }
        [JsonPropertyName("Win_Status")] 
        public string? WinStatus { get; init; }
        [JsonPropertyName("Winning_TaskForce")] 
        public int WinningTaskForce { get; init; }
        [JsonPropertyName("playerId")] 
        public int PlayerId { get; init; }
        [JsonPropertyName("playerName")] 
        public string? PlayerName { get; init; }
        [JsonPropertyName("ret_msg")]
        public object? RetMsg { get; init; }
    }
}
