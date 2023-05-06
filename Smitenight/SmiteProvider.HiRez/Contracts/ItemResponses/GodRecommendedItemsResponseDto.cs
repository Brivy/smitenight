using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Contracts.ItemResponses
{
    public record class GodRecommendedItemsResponseDto
    {
        [JsonPropertyName("Category")] public string? Category { get; set; }
        [JsonPropertyName("Item")] public string? Item { get; set; }
        [JsonPropertyName("Role")] public string? Role { get; set; }
        [JsonPropertyName("category_value_id")] public int CategoryValueId { get; set; }
        [JsonPropertyName("god_id")] public int GodId { get; set; }
        [JsonPropertyName("god_name")] public string? GodName { get; set; }
        [JsonPropertyName("icon_id")] public int IconId { get; set; }
        [JsonPropertyName("item_id")] public int ItemId { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
        [JsonPropertyName("role_value_id")] public int RoleValueId { get; set; }
    }
}
