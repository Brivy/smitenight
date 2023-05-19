using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.Contracts.Models
{
    public record CreateActiveDto
    {
        public int SmiteId { get; set; }
        public string Checksum { get; set; } = null!;
        public bool Enabled { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ItemTier ItemTier { get; set; }
        public int Price { get; set; }
        public string SecondaryDescription { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string ItemIconUrl { get; set; } = null!;
    }
}
