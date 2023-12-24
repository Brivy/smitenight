namespace Smitenight.Persistence.Data.Contracts.Models;

public class ActiveLinkDto
{
    public int? OldItemId { get; set; }
    public int NewItemId { get; set; }
    public int SmiteId { get; set; }
    public int? RootActiveId { get; set; }
    public int? ChildActiveId { get; set; }
}
