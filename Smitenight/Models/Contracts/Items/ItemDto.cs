using Smitenight.Domain.Models.Enums.Items;

namespace Smitenight.Domain.Models.Contracts.Items
{
    public class ItemDto
    {
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

        public ItemDto? RootItem { get; set; }
        public ItemDto? ChildItem { get; set; }
        public List<ItemDescriptionDto> ItemDescriptions { get; set; }
        public List<ItemPurchaseDto> ItemPurchases { get; set; }

        public ItemDto()
        {
            ItemDescriptions = new List<ItemDescriptionDto>();
            ItemPurchases = new List<ItemPurchaseDto>();
        }
    }
}
