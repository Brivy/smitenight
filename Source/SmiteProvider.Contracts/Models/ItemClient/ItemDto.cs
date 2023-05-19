namespace Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient
{
    public record class ItemDto
    {
        public string ActiveFlag { get; init; } = null!;
        public int ChildItemId { get; init; }
        public string DeviceName { get; init; } = null!;
        public string Glyph { get; init; } = null!;
        public int IconId { get; init; }
        public ItemDescriptionDto ItemDescription { get; init; } = null!;
        public int ItemId { get; init; }
        public int ItemTier { get; init; }
        public int Price { get; init; }
        public string RestrictedRoles { get; init; } = null!;
        public int RootItemId { get; init; }
        public string ShortDesc { get; init; } = null!;
        public bool StartingItem { get; init; }
        public string Type { get; init; } = null!;
        public string ItemIconUrl { get; init; } = null!;
        public string? RetMsg { get; init; }
    }
}
