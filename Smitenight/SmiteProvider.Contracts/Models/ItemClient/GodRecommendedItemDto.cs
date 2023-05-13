namespace Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient
{
    public record class GodRecommendedItemDto
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
