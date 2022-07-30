using SmitenightApp.Domain.Enums.Gods;
using SmitenightApp.Domain.Exceptions;
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

        private God? _god;

        public God God
        {
            get => _god ?? throw new NavigationPropertyNullException(nameof(God));
            set => _god = value;
        }

        public List<MatchDetail> MatchDetails { get; set; }

        #endregion

        public GodSkin()
        {
            MatchDetails = new List<MatchDetail>();
        }
    }
}
