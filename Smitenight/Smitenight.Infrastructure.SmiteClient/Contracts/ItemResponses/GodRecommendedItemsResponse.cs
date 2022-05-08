using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.ItemResponses
{
    public record class GodRecommendedItemsResponse
    (
        [property: JsonPropertyName("Category")] string Category,
        [property: JsonPropertyName("Item")] string Item,
        [property: JsonPropertyName("Role")] string Role,
        [property: JsonPropertyName("category_value_id")] int CategoryValueId,
        [property: JsonPropertyName("god_id")] int GodId,
        [property: JsonPropertyName("god_name")] string GodName,
        [property: JsonPropertyName("icon_id")] int IconId,
        [property: JsonPropertyName("item_id")] int ItemId,
        [property: JsonPropertyName("ret_msg")] object RetMsg,
        [property: JsonPropertyName("role_value_id")] int RoleValueId
    );
}
