using SmitenightApp.Domain.Enums.Items;
using SmitenightApp.Domain.Interfaces;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Domain.Models.Items
{
    public class ActivePurchase : IEntity
    {
        public int Id { get; set; }
        public int ActiveId { get; set; }
        public int MatchDetailId { get; set; }

        public ActivePurchaseOrderEnum ActivePurchaseOrder { get; set; }

        #region Navigation

        public Active Active { get; set; }
        public MatchDetail MatchDetail { get; set; }

        #endregion
    }
}
