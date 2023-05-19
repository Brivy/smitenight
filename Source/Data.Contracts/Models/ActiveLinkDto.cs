namespace Smitenight.Persistence.Data.Contracts.Models
{
    public class ActiveLinkDto
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }
        public int? RootActiveId { get; set; }
        public int? ChildActiveId { get; set; }
    }
}
