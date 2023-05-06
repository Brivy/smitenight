namespace Smitenight.Domain.Models.Clients.ItemClient
{
    public record class GodRecommendedItemsResponse
    (
        string Category,
        string Item,
        string Role,
        int CategoryValueId,
        int GodId,
        string GodName,
        int IconId,
        int ItemId,
        object RetMsg,
        int RoleValueId
    );
}
