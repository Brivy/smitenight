using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.TeamResponses
{
    public class TeamPlayersResponseDto
    {
        [JsonPropertyName("AccountLevel")] public int AccountLevel { get; set; }
        [JsonPropertyName("JoinedDatetime")] public string? JoinedDatetime { get; set; }
        [JsonPropertyName("LastLoginDatetime")] public string? LastLoginDatetime { get; set; }
        [JsonPropertyName("Name")] public string? Name { get; set; }
        [JsonPropertyName("PlayerId")] public string? PlayerId { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }
}
