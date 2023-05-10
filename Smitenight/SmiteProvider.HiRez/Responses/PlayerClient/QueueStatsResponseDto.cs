using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Responses.PlayerClient
{
    public record class QueueStatsResponseDto
    {
        [JsonPropertyName("Assists")] public int Assists { get; set; }
        [JsonPropertyName("Deaths")] public int Deaths { get; set; }
        [JsonPropertyName("God")] public string? God { get; set; }
        [JsonPropertyName("GodId")] public int GodId { get; set; }
        [JsonPropertyName("Gold")] public int Gold { get; set; }
        [JsonPropertyName("Kills")] public int Kills { get; set; }
        [JsonPropertyName("LastPlayed")] public string? LastPlayed { get; set; }
        [JsonPropertyName("Losses")] public int Losses { get; set; }
        [JsonPropertyName("Matches")] public int Matches { get; set; }
        [JsonPropertyName("Minutes")] public int Minutes { get; set; }
        [JsonPropertyName("Queue")] public string? Queue { get; set; }
        [JsonPropertyName("Wins")] public int Wins { get; set; }
        [JsonPropertyName("player_id")] public string? PlayerId { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }
}
