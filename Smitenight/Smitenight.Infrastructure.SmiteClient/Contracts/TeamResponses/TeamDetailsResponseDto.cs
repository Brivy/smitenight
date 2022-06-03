using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.TeamResponses
{
    public record class TeamDetailsResponseDto
    {
        [JsonPropertyName("AvatarURL")] public string? AvatarUrl { get; init; }
        [JsonPropertyName("Founder")] public string? Founder { get; init; }
        [JsonPropertyName("FounderId")] public string? FounderId { get; init; }
        [JsonPropertyName("Losses")] public int Losses { get; init; }
        [JsonPropertyName("Name")] public string? Name { get; init; }
        [JsonPropertyName("Players")] public int Players { get; init; }
        [JsonPropertyName("Rating")] public int Rating { get; init; }
        [JsonPropertyName("Tag")] public string? Tag { get; init; }
        [JsonPropertyName("TeamId")] public int TeamId { get; init; }
        [JsonPropertyName("Wins")] public int Wins { get; init; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; init; }
    }
}
