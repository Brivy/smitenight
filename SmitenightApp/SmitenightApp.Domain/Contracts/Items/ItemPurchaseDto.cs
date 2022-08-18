using SmitenightApp.Domain.Contracts.Matches;
using SmitenightApp.Domain.Enums.Items;

namespace SmitenightApp.Domain.Contracts.Items
{
    public class ItemPurchaseDto
    {
        public ItemPurchaseOrderEnum ItemPurchaseOrder { get; set; }

        public ItemDto? Item { get; set; }
        public MatchDetailDto? MatchDetail { get; set; }
    }
}
