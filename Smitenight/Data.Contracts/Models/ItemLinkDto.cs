namespace Smitenight.Persistence.Data.Contracts.Models
{
    public class ItemLinkDto
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }
        public int? RootItemId { get; set; }
        public int? ChildItemId { get; set; }
    }
}
