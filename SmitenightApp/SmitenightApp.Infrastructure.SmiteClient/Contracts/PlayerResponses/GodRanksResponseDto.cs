using System.Text.Json.Serialization;

namespace SmitenightApp.Infrastructure.SmiteClient.Contracts.PlayerResponses
{
    public record class GodRanksResponseDto
    {
        [JsonPropertyName("Assists")] public int Assists { get; set; }
        [JsonPropertyName("Deaths")] public int Deaths { get; set; }
        [JsonPropertyName("Kills")] public int Kills { get; set; }
        [JsonPropertyName("Losses")] public int Losses { get; set; }
        [JsonPropertyName("MinionKills")] public int MinionKills { get; set; }
        [JsonPropertyName("Rank")] public int Rank { get; set; }
        [JsonPropertyName("Wins")] public int Wins { get; set; }
        [JsonPropertyName("Worshippers")] public int Worshippers { get; set; }
        [JsonPropertyName("god")] public string? God { get; set; }
        [JsonPropertyName("god_id")] public string? GodId { get; set; }
        [JsonPropertyName("player_id")] public string? PlayerId { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }
}
