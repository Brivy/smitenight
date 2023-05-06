using Smitenight.Domain.Models.Contracts.Matches;
using Smitenight.Domain.Models.Enums.Items;

namespace Smitenight.Domain.Models.Contracts.Items
{
    public class ItemPurchaseDto
    {
        public ItemPurchaseOrderEnum ItemPurchaseOrder { get; set; }

        public ItemDto? Item { get; set; }
        public MatchDetailDto? MatchDetail { get; set; }
    }
}
