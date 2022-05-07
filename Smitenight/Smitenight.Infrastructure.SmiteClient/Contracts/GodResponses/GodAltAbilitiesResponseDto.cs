using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.GodResponses
{
    public record class GodAltAbilitiesResponseDto(
        [property: JsonPropertyName("alt_name")] string AltName,
        [property: JsonPropertyName("alt_position")] string AltPosition,
        [property: JsonPropertyName("god")] string God,
        [property: JsonPropertyName("god_id")] int GodId,
        [property: JsonPropertyName("item_id")] int ItemId,
        [property: JsonPropertyName("ret_msg")] object RetMsg);
}
