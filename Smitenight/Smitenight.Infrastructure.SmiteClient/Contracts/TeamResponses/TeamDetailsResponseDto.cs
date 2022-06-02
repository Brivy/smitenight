using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.TeamResponses
{
    public class TeamDetailsResponseDto
    {
        [JsonPropertyName("AvatarURL")] public string? AvatarUrl { get; set; }
        [JsonPropertyName("Founder")] public string? Founder { get; set; }
        [JsonPropertyName("FounderId")] public string? FounderId { get; set; }
        [JsonPropertyName("Losses")] public int Losses { get; set; }
        [JsonPropertyName("Name")] public string? Name { get; set; }
        [JsonPropertyName("Players")] public int Players { get; set; }
        [JsonPropertyName("Rating")] public int Rating { get; set; }
        [JsonPropertyName("Tag")] public string? Tag { get; set; }
        [JsonPropertyName("TeamId")] public int TeamId { get; set; }
        [JsonPropertyName("Wins")] public int Wins { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }
}
