using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class ActivePurchase
    {
        public int Id { get; set; }
        public int ActiveId { get; set; }
        public int MatchDetailId { get; set; }

        public ActivePurchaseOrder ActivePurchaseOrder { get; set; }

        #region Navigation

        public Active? Active { get; set; }
        public MatchDetail? MatchDetail { get; set; }

        #endregion
    }
}
