using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class GodSkin
    {
        public int Id { get; set; }
        public int GodId { get; set; }
        public int SmiteId { get; set; }
        public int SecondarySmiteId { get; set; }

        public string Checksum { get; set; } = null!;
        public string? GodSkinUrl { get; set; }
        public string Name { get; set; } = null!;
        public GodSkinsObtainability Obtainability { get; set; }
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
