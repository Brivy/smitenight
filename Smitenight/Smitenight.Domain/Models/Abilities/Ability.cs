using Smitenight.Domain.Enums.Ability;
using Smitenight.Domain.Exceptions;
using Smitenight.Domain.Interfaces;
using Smitenight.Domain.Models.Gods;

namespace Smitenight.Domain.Models.Abilities
{
    public class Ability : IEntity
    {
        public int Id { get; set; }
        public int GodId { get; set; }
        public int SmiteId { get; set; }

        public string? Cooldown { get; set; }
        public string? Cost { get; set; }
        public string Description { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Url { get; set; } = null!;

        public AbilityTypeEnum AbilityType { get; set; }

        #region Navigation

        private God? _god;

        public God God
        {
            get => _god ?? throw new NavigationPropertyNullException(nameof(God));
            set => _god = value;
        }

        public List<AbilityRank> AbilityRanks { get; set; }
        public List<AbilityTag> AbilityTags { get; set; }

        #endregion

        public Ability()
        {
            AbilityRanks = new List<AbilityRank>();
            AbilityTags = new List<AbilityTag>();
        }
    }
}
