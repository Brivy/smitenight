using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }
        public int? RootItemId { get; set; }
        public int? ChildItemId { get; set; }

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

        #region Navigation

        public Item? RootItem { get; set; }
        public Item? ChildItem { get; set; }

        public IEnumerable<ItemDescription> ItemDescriptions { get; set; }
        public IEnumerable<ItemPurchase> ItemPurchases { get; set; }

        #endregion

        public Item()
        {
            ItemDescriptions = new List<ItemDescription>();
            ItemPurchases = new List<ItemPurchase>();
        }
    }
}
