using Smitenight.Domain.Models.Contracts.Gods;
using Smitenight.Domain.Models.Enums.Ability;

namespace Smitenight.Domain.Models.Contracts.Abilities
{
    public class AbilityDto
    {
        public string? Cooldown { get; set; }
        public string? Cost { get; set; }
        public string Description { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Url { get; set; } = null!;
        public AbilityTypeEnum AbilityType { get; set; }

        public GodDto? God { get; set; }
        public List<AbilityRankDto> AbilityRanks { get; set; }
        public List<AbilityTagDto> AbilityTags { get; set; }

        public AbilityDto()
        {
            AbilityRanks = new List<AbilityRankDto>();
            AbilityTags = new List<AbilityTagDto>();
        }
    }
}
