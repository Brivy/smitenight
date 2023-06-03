using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class Active
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }
        public int? RootActiveId { get; set; } // Root is not the same as a parent. Root is the base item that all other actives are built from.
        public int? ChildActiveId { get; set; }
        public int PatchId { get; set; }

        public string Checksum { get; set; } = null!;
        public bool Enabled { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ItemTier ItemTier { get; set; }
        public int Price { get; set; }
        public string? SecondaryDescription { get; set; } = null!;
        public string? ShortDescription { get; set; } = null!;
        public string ItemIconUrl { get; set; } = null!;
        public bool Latest { get; set; }

        public Patch? Patch { get; set; }
        public Active? RootActive { get; set; }
        public Active? ChildActive { get; set; }
        public ICollection<ActivePurchase> ActivePurchases { get; set; }

        public Active()
        {
            ActivePurchases = new List<ActivePurchase>();
        }
    }
}
