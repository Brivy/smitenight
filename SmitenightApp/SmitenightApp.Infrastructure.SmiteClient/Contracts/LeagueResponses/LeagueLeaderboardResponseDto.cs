using System.Text.Json.Serialization;

namespace SmitenightApp.Infrastructure.SmiteClient.Contracts.LeagueResponses
{
    public record class LeagueLeaderboardResponseDto
    {
        [JsonPropertyName("Leaves")] public int Leaves { get; set; }
        [JsonPropertyName("Losses")] public int Losses { get; set; }
        [JsonPropertyName("Name")] public string? Name { get; set; }
        [JsonPropertyName("Points")] public int Points { get; set; }
        [JsonPropertyName("PrevRank")] public int PrevRank { get; set; }
        [JsonPropertyName("Rank")] public int Rank { get; set; }
        [JsonPropertyName("Rank_Stat")] public int RankStat { get; set; }
        [JsonPropertyName("Rank_Stat_Conquest")] public string? RankStatConquest { get; set; }
        [JsonPropertyName("Rank_Stat_Joust")] public string? RankStatJoust { get; set; }
        [JsonPropertyName("Rank_Variance")] public int RankVariance { get; set; }
        [JsonPropertyName("Round")] public int Round { get; set; }
        [JsonPropertyName("Season")] public int Season { get; set; }
        [JsonPropertyName("Tier")] public int Tier { get; set; }
        [JsonPropertyName("Trend")] public int Trend { get; set; }
        [JsonPropertyName("Wins")] public int Wins { get; set; }
        [JsonPropertyName("player_id")] public string? PlayerId { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }
}
