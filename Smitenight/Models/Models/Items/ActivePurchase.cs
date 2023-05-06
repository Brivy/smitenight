using Smitenight.Domain.Models.Enums.Items;
using Smitenight.Domain.Models.Interfaces;
using Smitenight.Domain.Models.Models.Matches;

namespace Smitenight.Domain.Models.Models.Items
{
    public class ActivePurchase : IEntity
    {
        public int Id { get; set; }
        public int ActiveId { get; set; }
        public int MatchDetailId { get; set; }

        public ActivePurchaseOrderEnum ActivePurchaseOrder { get; set; }

        #region Navigation

        public Active? Active { get; set; }
        public MatchDetail? MatchDetail { get; set; }

        #endregion
    }
}
