using SmitenightApp.Domain.Enums.Items;
using SmitenightApp.Domain.Interfaces;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Domain.Models.Items
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
