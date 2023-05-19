namespace Smitenight.Persistence.Data.Contracts.Models
{
    public class UpdateItemLinkDto
    {
        public int Id { get; set; }
        public int? RootItemId { get; set; }
        public int? ChildItemId { get; set; }
    }
}
