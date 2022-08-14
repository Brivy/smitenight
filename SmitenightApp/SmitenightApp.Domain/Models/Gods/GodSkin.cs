using SmitenightApp.Domain.Enums.Gods;
using SmitenightApp.Domain.Interfaces;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Domain.Models.Gods
{
    public class GodSkin : IEntity
    {
        public int Id { get; set; }
        public int GodId { get; set; }
        public int SmiteId { get; set; }
        public int SecondarySmiteId { get; set; }

        public string? GodSkinUrl { get; set; }
        public string Name { get; set; } = null!;
        public GodSkinsObtainabilityEnum Obtainability { get; set; }
        public int PriceFavor { get; set; }
        public int PriceGems { get; set; }

        #region Navigation

        public God? God { get; set; }
        public List<MatchDetail> MatchDetails { get; set; }

        #endregion

        public GodSkin()
        {
            MatchDetails = new List<MatchDetail>();
        }
    }
}
