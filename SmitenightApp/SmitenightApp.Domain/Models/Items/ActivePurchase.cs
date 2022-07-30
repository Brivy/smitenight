using SmitenightApp.Domain.Enums.Items;
using SmitenightApp.Domain.Exceptions;
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

        private Active? _active;
        private MatchDetail? _matchDetail;

        public Active Active
        {
            get => _active ?? throw new NavigationPropertyNullException(nameof(Active));
            set => _active = value;
        }

        public MatchDetail MatchDetail
        {
            get => _matchDetail ?? throw new NavigationPropertyNullException(nameof(MatchDetail));
            set => _matchDetail = value;
        }

        #endregion

        public ActivePurchase()
        {

        }
    }
}
