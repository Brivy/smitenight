using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.TeamResponses
{
    public class SearchTeamsResponseDto
    {
        [JsonPropertyName("Founder")] public string? Founder { get; set; }
        [JsonPropertyName("Name")] public string? Name { get; set; }
        [JsonPropertyName("Players")] public int Players { get; set; }
        [JsonPropertyName("Tag")] public string? Tag { get; set; }
        [JsonPropertyName("TeamId")] public int TeamId { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }
}
