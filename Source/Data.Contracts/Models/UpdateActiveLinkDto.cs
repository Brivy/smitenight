namespace Smitenight.Persistence.Data.Contracts.Models
{
    public class UpdateActiveLinkDto
    {
        public int Id { get; set; }
        public int? RootActiveId { get; set; }
        public int? ChildActiveId { get; set; }
    }
}
