using Smitenight.Domain.Enums.Items;
using Smitenight.Domain.Exceptions;
using Smitenight.Domain.Interfaces;

namespace Smitenight.Domain.Models.Items
{
    public class Item : IEntity
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }
        public int? RootItemId { get; set; }
        public int? ChildItemId { get; set; }

        public bool Enabled { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Glyph { get; set; }
        public ItemTierEnum ItemTier { get; set; }
        public int Price { get; set; }
        public RestrictedRolesEnum RestrictedRoles { get; set; }
        public string? SecondaryDescription { get; set; }
        public string? ShortDescription { get; set; }
        public bool StartingItem { get; set; }
        public string ItemIconUrl { get; set; } = null!;

        #region Navigation

        private Item? _rootItem;
        private Item? _childItem;

        public Item RootItem
        {
            get => _rootItem ?? throw new NavigationPropertyNullException(nameof(RootItem));
            set => _rootItem = value;
        }

        public Item ChildItem
        {
            get => _childItem ?? throw new NavigationPropertyNullException(nameof(ChildItem));
            set => _childItem = value;
        }

        public List<ItemDescription> ItemDescriptions { get; set; }
        public List<ItemPurchase> ItemPurchases { get; set; }

        #endregion

        public Item()
        {
            ItemDescriptions = new List<ItemDescription>();
            ItemPurchases = new List<ItemPurchase>();
        }
    }
}
