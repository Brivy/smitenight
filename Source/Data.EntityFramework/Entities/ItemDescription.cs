namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class ItemDescription
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string Checksum { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        public Item? Item { get; set; }
    }
}
