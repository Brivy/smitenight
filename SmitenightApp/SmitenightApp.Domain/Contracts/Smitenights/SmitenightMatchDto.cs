using SmitenightApp.Domain.Contracts.Matches;

namespace SmitenightApp.Domain.Contracts.Smitenights
{
    public class SmitenightMatchDto
    {
        public MatchDto? Match { get; set; }
        public SmitenightDto? Smitenight { get; set; }
    }
}
