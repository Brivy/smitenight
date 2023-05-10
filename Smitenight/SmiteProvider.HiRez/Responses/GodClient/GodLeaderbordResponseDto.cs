using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Responses.GodClient
{
    public record class GodLeaderbordResponseDto
    {
        [JsonPropertyName("god_id")] public string? GodId { get; set; }
        [JsonPropertyName("losses")] public string? Losses { get; set; }
        [JsonPropertyName("player_id")] public string? PlayerId { get; set; }
        [JsonPropertyName("player_name")] public string? PlayerName { get; set; }
        [JsonPropertyName("player_ranking")] public string? PlayerRanking { get; set; }
        [JsonPropertyName("rank")] public string? Rank { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
        [JsonPropertyName("wins")] public string? Wins { get; set; }
    }
}
