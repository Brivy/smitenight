namespace Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;

public record class ItemDto
{
    public required string ActiveFlag { get; init; }
    public int? ChildItemId { get; init; }
    public required string DeviceName { get; init; }
    public required string Glyph { get; init; }
    public required int IconId { get; init; }
    public required ItemDescriptionDto ItemDescription { get; init; }
    public required int ItemId { get; init; }
    public required int ItemTier { get; init; }
    public required int Price { get; init; }
    public required string RestrictedRoles { get; init; }
    public int? RootItemId { get; init; }
    public required string ShortDesc { get; init; }
    public required bool StartingItem { get; init; }
    public required string Type { get; init; }
    public required string ItemIconUrl { get; init; }
    public string? RetMsg { get; init; }
}
