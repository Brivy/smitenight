using Smitenight.Domain.Models.Enums.Items;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class ItemPurchase
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int MatchDetailId { get; set; }

        public ItemPurchaseOrderEnum ItemPurchaseOrder { get; set; }

        #region Navigation

        public Item? Item { get; set; }
        public MatchDetail? MatchDetail { get; set; }

        #endregion
    }
}
