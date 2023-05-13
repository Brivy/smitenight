namespace Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient
{
    public record class ItemDto
    (
        string ActiveFlag,
        int ChildItemId,
        string DeviceName,
        string Glyph,
        int IconId,
        ItemDescriptionDto ItemDescription,
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

    public record class ItemDescriptionDto
    (
        string? Description,
        MenuItemDto[] MenuItems,
        string? SecondaryDescription
    );

    public record class MenuItemDto
    (
        string Description,
        string Value
    );
}
