using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class Active
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }
        public int? RootActiveId { get; set; }
        public int? ChildActiveId { get; set; }

        public string Checksum { get; set; } = null!;
        public bool Enabled { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ItemTier ItemTier { get; set; }
        public int Price { get; set; }
        public string SecondaryDescription { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string ItemIconUrl { get; set; } = null!;

        public Active? RootActive { get; set; }
        public Active? ChildActive { get; set; }

        public List<ActivePurchase> ActivePurchases { get; set; }

        public Active()
        {
            ActivePurchases = new List<ActivePurchase>();
        }
    }
}
