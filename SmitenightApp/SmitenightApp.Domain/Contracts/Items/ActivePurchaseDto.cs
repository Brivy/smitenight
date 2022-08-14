using SmitenightApp.Domain.Enums.Items;
using SmitenightApp.Domain.Contracts.Matches;

namespace SmitenightApp.Domain.Contracts.Items
{
    public class ActivePurchaseDto
    {
        public ActivePurchaseOrderEnum ActivePurchaseOrder { get; set; }

        public ActiveDto? Active { get; set; }
        public MatchDetailDto? MatchDetail { get; set; }
    }
}
