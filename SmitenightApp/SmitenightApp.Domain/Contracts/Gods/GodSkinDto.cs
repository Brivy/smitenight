using SmitenightApp.Domain.Contracts.Matches;
using SmitenightApp.Domain.Enums.Gods;

namespace SmitenightApp.Domain.Contracts.Gods
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
