namespace Smitenight.Domain.Models.Clients.ItemClient
{
    public record class ItemsResponse
    (
        string ActiveFlag,
        int ChildItemId,
        string DeviceName,
        string Glyph,
        int IconId,
        ItemDescription ItemDescription,
        int ItemId,
        int ItemTier,
        int Price,
        string RestrictedRoles,
        int RootItemId,
        string ShortDesc,
        bool StartingItem,
        string Type,
        string ItemIconUrl,
        object RetMsg
    );

    public record class ItemDescription
    (
        string? Description,
        MenuItem[] MenuItems,
        string? SecondaryDescription
    );

    public record class MenuItem
    (
        string Description,
        string Value
    );
}
