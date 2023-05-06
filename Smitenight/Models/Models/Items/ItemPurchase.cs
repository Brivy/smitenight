using Smitenight.Domain.Models.Enums.Items;
using Smitenight.Domain.Models.Interfaces;
using Smitenight.Domain.Models.Models.Matches;

namespace Smitenight.Domain.Models.Models.Items
{
    public class ItemPurchase : IEntity
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
