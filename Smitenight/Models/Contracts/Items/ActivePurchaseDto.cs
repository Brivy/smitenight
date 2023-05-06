using Smitenight.Domain.Models.Enums.Items;
using Smitenight.Domain.Models.Contracts.Matches;

namespace Smitenight.Domain.Models.Contracts.Items
{
    public class ActivePurchaseDto
    {
        public ActivePurchaseOrderEnum ActivePurchaseOrder { get; set; }

        public ActiveDto? Active { get; set; }
        public MatchDetailDto? MatchDetail { get; set; }
    }
}
