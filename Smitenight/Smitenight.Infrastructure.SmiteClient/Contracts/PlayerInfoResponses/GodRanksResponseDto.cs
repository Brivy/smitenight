using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.PlayerInfoResponses
{
    public record class GodRanksResponseDto
    (
        [property: JsonPropertyName("Assists")] int Assists,
        [property: JsonPropertyName("Deaths")] int Deaths,
        [property: JsonPropertyName("Kills")] int Kills,
        [property: JsonPropertyName("Losses")] int Losses,
        [property: JsonPropertyName("MinionKills")] int MinionKills,
        [property: JsonPropertyName("Rank")] int Rank,
        [property: JsonPropertyName("Wins")] int Wins,
        [property: JsonPropertyName("Worshippers")] int Worshippers,
        [property: JsonPropertyName("god")] string God,
        [property: JsonPropertyName("god_id")] string GodId,
        [property: JsonPropertyName("player_id")] string PlayerId,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );
}
