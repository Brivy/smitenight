using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.GodResponses
{
    public record class GodLeaderbordResponseDto(
        [property: JsonPropertyName("god_id")] string GodId,
        [property: JsonPropertyName("losses")] string Losses,
        [property: JsonPropertyName("player_id")] string PlayerId,
        [property: JsonPropertyName("player_name")] string PlayerName,
        [property: JsonPropertyName("player_ranking")] string PlayerRanking,
        [property: JsonPropertyName("rank")] string Rank,
        [property: JsonPropertyName("ret_msg")] object RetMsg,
        [property: JsonPropertyName("wins")] string Wins);
}
