using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Responses.MatchClient
{
    public record class MatchIdsByQueueResponseDto
    {
        [JsonPropertyName("Active_Flag")] public string? ActiveFlag { get; init; }
        [JsonPropertyName("Match")] public string? Match { get; init; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; init; }
    }
}
