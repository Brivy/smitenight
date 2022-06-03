using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.TeamResponses
{
    public record class TeamPlayersResponseDto
    {
        [JsonPropertyName("AccountLevel")] public int AccountLevel { get; init; }
        [JsonPropertyName("JoinedDatetime")] public string? JoinedDatetime { get; init; }
        [JsonPropertyName("LastLoginDatetime")] public string? LastLoginDatetime { get; init; }
        [JsonPropertyName("Name")] public string? Name { get; init; }
        [JsonPropertyName("PlayerId")] public string? PlayerId { get; init; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; init; }
    }
}
