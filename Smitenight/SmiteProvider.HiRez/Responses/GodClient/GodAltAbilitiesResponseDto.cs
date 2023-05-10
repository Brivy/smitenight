using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Responses.GodClient
{
    public record class GodAltAbilitiesResponseDto
    {
        [JsonPropertyName("alt_name")] public string? AltName { get; set; }
        [JsonPropertyName("alt_position")] public string? AltPosition { get; set; }
        [JsonPropertyName("god")] public string? God { get; set; }
        [JsonPropertyName("god_id")] public int GodId { get; set; }
        [JsonPropertyName("item_id")] public int ItemId { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }
}
