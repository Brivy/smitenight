using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class Ability
    {
        public int Id { get; set; }
        public int GodId { get; set; }
        public int SmiteId { get; set; }

        public string? Cooldown { get; set; }
        public string? Cost { get; set; }
        public string Description { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Url { get; set; } = null!;
        public AbilityType AbilityType { get; set; }

        #region Navigation

        public God? God { get; set; }

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
