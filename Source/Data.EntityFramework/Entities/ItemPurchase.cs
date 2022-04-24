using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities;

public class ItemPurchase
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int MatchDetailId { get; set; }

    public ItemPurchaseOrder PurchaseOrder { get; set; }

    public Item? Item { get; set; }
    public MatchDetail? MatchDetail { get; set; }
}
