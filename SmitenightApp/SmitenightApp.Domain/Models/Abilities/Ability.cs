using SmitenightApp.Domain.Enums.Ability;
using SmitenightApp.Domain.Interfaces;
using SmitenightApp.Domain.Models.Gods;

namespace SmitenightApp.Domain.Models.Abilities
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
