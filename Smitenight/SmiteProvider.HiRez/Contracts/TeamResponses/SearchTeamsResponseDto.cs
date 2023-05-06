using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Contracts.TeamResponses
{
    public record class SearchTeamsResponseDto
    {
        [JsonPropertyName("Founder")] public string? Founder { get; init; }
        [JsonPropertyName("Name")] public string? Name { get; init; }
        [JsonPropertyName("Players")] public int Players { get; init; }
        [JsonPropertyName("Tag")] public string? Tag { get; init; }
        [JsonPropertyName("TeamId")] public int TeamId { get; init; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; init; }
    }
}
