using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.GodResponses
{
    public record class GodSkinsResponseDto(
        [property: JsonPropertyName("godIcon_URL")] string GodIconUrl,
        [property: JsonPropertyName("godSkin_URL")] string GodSkinUrl,
        [property: JsonPropertyName("god_id")] int GodId,
        [property: JsonPropertyName("god_name")] string GodName,
        [property: JsonPropertyName("obtainability")] string Obtainability,
        [property: JsonPropertyName("price_favor")] int PriceFavor,
        [property: JsonPropertyName("price_gems")] int PriceGems,
        [property: JsonPropertyName("ret_msg")] object RetMsg,
        [property: JsonPropertyName("skin_id1")] int SkinId1,
        [property: JsonPropertyName("skin_id2")] int SkinId2,
        [property: JsonPropertyName("skin_name")] string SkinName
    );
}
