using Smitenight.Domain.Exceptions;
using Smitenight.Domain.Interfaces;

namespace Smitenight.Domain.Models.Items
{
    public class Item : IEntity
    {
        public int Id { get; set; }
        public int? RootItemId { get; set; }
        public int? ChildItemId { get; set; }

        public string ActiveFlag { get; set; }
        public string DeviceName { get; set; }
        public string Description { get; set; }
        public string Glyph { get; set; }
        public int ItemTier { get; set; }
        public int Price { get; set; }
        public string RestrictedRoles { get; set; }
        public string? SecondaryDescription { get; set; }
        public string ShortDescription { get; set; }
        public bool StartingItem { get; set; }
        public string Type { get; set; }
        public string ItemIconUrl { get; set; }

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

        public Item(string activeFlag, string deviceName, string description, string glyph, string restrictedRoles, string shortDescription, string type, string itemIconUrl)
        {
            ActiveFlag = activeFlag;
            DeviceName = deviceName;
            Description = description;
            Glyph = glyph;
            RestrictedRoles = restrictedRoles;
            ShortDescription = shortDescription;
            Type = type;
            ItemIconUrl = itemIconUrl;
            ItemDescriptions = new List<ItemDescription>();
        }
    }
}
