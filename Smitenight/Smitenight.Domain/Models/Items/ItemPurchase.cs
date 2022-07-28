using Smitenight.Domain.Enums.Items;
using Smitenight.Domain.Exceptions;
using Smitenight.Domain.Interfaces;
using Smitenight.Domain.Models.Matches;

namespace Smitenight.Domain.Models.Items
{
    public class ItemPurchase : IEntity
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int MatchDetailId { get; set; }

        public ItemPurchaseOrderEnum ItemPurchaseOrder { get; set; }

        #region Navigation

        private Item? _item;
        private MatchDetail? _matchDetail;

        public Item Item
        {
            get => _item ?? throw new NavigationPropertyNullException(nameof(Item));
            set => _item = value;
        }

        public MatchDetail MatchDetail
        {
            get => _matchDetail ?? throw new NavigationPropertyNullException(nameof(MatchDetail));
            set => _matchDetail = value;
        }

        #endregion

        public ItemPurchase()
        {

        }
    }
}
