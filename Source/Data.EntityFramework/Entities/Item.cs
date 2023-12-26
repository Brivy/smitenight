using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities;

internal class Item
{
    public int Id { get; set; }
    public int SmiteId { get; set; }
    public int? RootItemId { get; set; } // Root is not the same as a parent. Root is the base item that all other items are built from.
    public int? ChildItemId { get; set; }
    public int PatchId { get; set; }

    public string Checksum { get; set; } = null!;
    public bool Enabled { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool Glyph { get; set; }
    public ItemTier ItemTier { get; set; }
    public int Price { get; set; }
    public RestrictedRoles RestrictedRoles { get; set; }
    public string? SecondaryDescription { get; set; }
    public string? ShortDescription { get; set; }
    public bool StartingItem { get; set; }
    public string ItemIconUrl { get; set; } = null!;
    public bool Latest { get; set; }

    public Patch? Patch { get; set; }
    public Item? RootItem { get; set; }
    public Item? ChildItem { get; set; }
    public ICollection<ItemDescription> ItemDescriptions { get; set; }
    public ICollection<ItemPurchase> ItemPurchases { get; set; }

    public Item()
    {
        ItemDescriptions = new List<ItemDescription>();
        ItemPurchases = new List<ItemPurchase>();
    }
}
