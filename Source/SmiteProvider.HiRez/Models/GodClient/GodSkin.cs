using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;

public record class GodSkin
{
    [JsonPropertyName("godIcon_URL")] public string? GodIconUrl { get; set; }
    [JsonPropertyName("godSkin_URL")] public string? GodSkinUrl { get; set; }
    [JsonPropertyName("god_id")] public int GodId { get; set; }
    [JsonPropertyName("god_name")] public string? GodName { get; set; }
    [JsonPropertyName("obtainability")] public string? Obtainability { get; set; }
    [JsonPropertyName("price_favor")] public int PriceFavor { get; set; }
    [JsonPropertyName("price_gems")] public int PriceGems { get; set; }
    [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    [JsonPropertyName("skin_id1")] public int SkinId1 { get; set; }
    [JsonPropertyName("skin_id2")] public int SkinId2 { get; set; }
    [JsonPropertyName("skin_name")] public string? SkinName { get; set; }
}
