using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.PlayerInfoResponses
{
    public record class QueueStatsResponseDto
    (
        [property: JsonPropertyName("Assists")] int Assists,
        [property: JsonPropertyName("Deaths")] int Deaths,
        [property: JsonPropertyName("God")] string God,
        [property: JsonPropertyName("GodId")] int GodId,
        [property: JsonPropertyName("Gold")] int Gold,
        [property: JsonPropertyName("Kills")] int Kills,
        [property: JsonPropertyName("LastPlayed")] string LastPlayed,
        [property: JsonPropertyName("Losses")] int Losses,
        [property: JsonPropertyName("Matches")] int Matches,
        [property: JsonPropertyName("Minutes")] int Minutes,
        [property: JsonPropertyName("Queue")] string Queue,
        [property: JsonPropertyName("Wins")] int Wins,
        [property: JsonPropertyName("player_id")] string PlayerId,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );
}
