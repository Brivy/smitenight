using Smitenight.Domain.Models.Contracts.Matches;
using Smitenight.Domain.Models.Enums.Gods;

namespace Smitenight.Domain.Models.Contracts.Gods
{
    public class GodSkinDto
    {
        public string? GodSkinUrl { get; set; }
        public string Name { get; set; } = null!;
        public GodSkinsObtainabilityEnum Obtainability { get; set; }
        public int PriceFavor { get; set; }
        public int PriceGems { get; set; }

        public GodDto? God { get; set; }
        public List<MatchDetailDto> MatchDetails { get; set; }

        public GodSkinDto()
        {
            MatchDetails = new List<MatchDetailDto>();
        }
    }
}
