using Smitenight.Domain.Models.Contracts.Matches;

namespace Smitenight.Domain.Models.Contracts.Smitenights
{
    public class SmitenightMatchDto
    {
        public MatchDto? Match { get; set; }
        public SmitenightDto? Smitenight { get; set; }
    }
}
