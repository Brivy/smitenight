using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient
{
    public record class MatchIdsByQueue
    {
        [JsonPropertyName("Active_Flag")] public string? ActiveFlag { get; init; }
        [JsonPropertyName("Match")] public string? Match { get; init; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; init; }
    }
}
