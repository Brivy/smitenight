namespace Smitenight.Persistence.Data.Contracts.Models
{
    public class ItemChecksumsDto
    {
        public int ItemId { get; set; }
        public int SmiteItemId { get; set; }
        public string Checksum { get; set; } = null!;
    }
}
