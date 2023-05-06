using Smitenight.Domain.Models.Contracts.Matches;
using Smitenight.Domain.Models.Enums.Gods;

namespace Smitenight.Domain.Models.Contracts.Gods
{
    public class GodBanDto
    {
        public GodBanOrderEnum GodBanOrder { get; set; }

        public GodDto? God { get; set; }
        public MatchDto? Match { get; set; }
    }
}
