using SmitenightApp.Domain.Enums.Gods;
using SmitenightApp.Domain.Contracts.Matches;

namespace SmitenightApp.Domain.Contracts.Gods
{
    public class GodBanDto
    {
        public GodBanOrderEnum GodBanOrder { get; set; }

        public GodDto? God { get; set; }
        public MatchDto? Match { get; set; }
    }
}
