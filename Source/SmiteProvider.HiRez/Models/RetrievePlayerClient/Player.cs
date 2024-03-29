﻿using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.RetrievePlayerClient;

public record class Player
{
    [JsonPropertyName("ActivePlayerId")] public int ActivePlayerId { get; set; }
    [JsonPropertyName("Avatar_URL")] public string? AvatarUrl { get; set; }
    [JsonPropertyName("Created_Datetime")] public string? CreatedDatetime { get; set; }
    [JsonPropertyName("HoursPlayed")] public int HoursPlayed { get; set; }
    [JsonPropertyName("Id")] public int Id { get; set; }
    [JsonPropertyName("Last_Login_Datetime")] public string? LastLoginDatetime { get; set; }
    [JsonPropertyName("Leaves")] public int Leaves { get; set; }
    [JsonPropertyName("Level")] public int Level { get; set; }
    [JsonPropertyName("Losses")] public int Losses { get; set; }
    [JsonPropertyName("MasteryLevel")] public int MasteryLevel { get; set; }
    [JsonPropertyName("MergedPlayers")] public string? MergedPlayers { get; set; } // No clue what this is/does so keep it a string
    [JsonPropertyName("MinutesPlayed")] public int MinutesPlayed { get; set; }
    [JsonPropertyName("Name")] public string? Name { get; set; }
    [JsonPropertyName("Personal_Status_Message")] public string? PersonalStatusMessage { get; set; }
    [JsonPropertyName("Platform")] public string? Platform { get; set; }
    [JsonPropertyName("Rank_Stat_Conquest")] public float RankStatConquest { get; set; }
    [JsonPropertyName("Rank_Stat_Conquest_Controller")] public float RankStatConquestController { get; set; }
    [JsonPropertyName("Rank_Stat_Duel")] public float RankStatDuel { get; set; }
    [JsonPropertyName("Rank_Stat_Duel_Controller")] public float RankStatDuelController { get; set; }
    [JsonPropertyName("Rank_Stat_Joust")] public float RankStatJoust { get; set; }
    [JsonPropertyName("Rank_Stat_Joust_Controller")] public float RankStatJoustController { get; set; }
    [JsonPropertyName("RankedConquest")] public RankedDetails RankedConquest { get; set; } = null!;
    [JsonPropertyName("RankedConquestController")] public RankedDetails RankedConquestController { get; set; } = null!;
    [JsonPropertyName("RankedDuel")] public RankedDetails RankedDuel { get; set; } = null!;
    [JsonPropertyName("RankedDuelController")] public RankedDetails RankedDuelController { get; set; } = null!;
    [JsonPropertyName("RankedJoust")] public RankedDetails RankedJoust { get; set; } = null!;
    [JsonPropertyName("RankedJoustController")] public RankedDetails RankedJoustController { get; set; } = null!;
    [JsonPropertyName("Region")] public string? Region { get; set; }
    [JsonPropertyName("TeamId")] public int TeamId { get; set; }
    [JsonPropertyName("Team_Name")] public string? TeamName { get; set; }
    [JsonPropertyName("Tier_Conquest")] public int TierConquest { get; set; }
    [JsonPropertyName("Tier_Duel")] public int TierDuel { get; set; }
    [JsonPropertyName("Tier_Joust")] public int TierJoust { get; set; }
    [JsonPropertyName("Total_Achievements")] public int TotalAchievements { get; set; }
    [JsonPropertyName("Total_Worshippers")] public int TotalWorshippers { get; set; }
    [JsonPropertyName("Wins")] public int Wins { get; set; }
    [JsonPropertyName("hz_gamer_tag")] public string? HzGamerTag { get; set; }
    [JsonPropertyName("hz_player_name")] public string? HzPlayerName { get; set; }
    [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
}

public record class RankedDetails
{
    [JsonPropertyName("Leaves")] public int Leaves { get; set; }
    [JsonPropertyName("Losses")] public int Losses { get; set; }
    [JsonPropertyName("Name")] public string? Name { get; set; }
    [JsonPropertyName("Points")] public int Points { get; set; }
    [JsonPropertyName("PrevRank")] public int PrevRank { get; set; }
    [JsonPropertyName("Rank")] public int Rank { get; set; }
    [JsonPropertyName("Rank_Stat")] public float RankStat { get; set; }
    [JsonPropertyName("Rank_Stat_Conquest")] public int? RankStatConquest { get; set; }
    [JsonPropertyName("Rank_Stat_Joust")] public int? RankStatJoust { get; set; }
    [JsonPropertyName("Rank_Variance")] public int RankVariance { get; set; }
    [JsonPropertyName("Round")] public int Round { get; set; }
    [JsonPropertyName("Season")] public int Season { get; set; }
    [JsonPropertyName("Tier")] public int Tier { get; set; }
    [JsonPropertyName("Trend")] public int Trend { get; set; }
    [JsonPropertyName("Wins")] public int Wins { get; set; }
    [JsonPropertyName("player_id")] public int PlayerId { get; set; }
    [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
}
