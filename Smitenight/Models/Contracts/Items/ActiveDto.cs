using Smitenight.Domain.Models.Enums.Items;

namespace Smitenight.Domain.Models.Contracts.Items
{
    public class ActiveDto
    {
        public bool Enabled { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ItemTierEnum ItemTier { get; set; }
        public int Price { get; set; }
        public string SecondaryDescription { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string ItemIconUrl { get; set; } = null!;

        public ActiveDto? RootActive { get; set; }
        public ActiveDto? ChildActive { get; set; }
        public List<ActivePurchaseDto> ActivePurchases { get; set; }

        public ActiveDto()
        {
            ActivePurchases = new List<ActivePurchaseDto>();
        }
    }
}
