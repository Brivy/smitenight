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

        public string ActiveFlag { get; set; } = null!;
        public string DeviceName { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string Glyph { get; set; } = null!;
        public int ItemTier { get; set; }
        public int Price { get; set; }
        public string RestrictedRoles { get; set; } = null!;
        public string? SecondaryDescription { get; set; }
        public string ShortDescription { get; set; } = null!;
        public bool StartingItem { get; set; }
        public string Type { get; set; } = null!;
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

        #endregion

        public Item()
        {
            ItemDescriptions = new List<ItemDescription>();
        }
    }
}
