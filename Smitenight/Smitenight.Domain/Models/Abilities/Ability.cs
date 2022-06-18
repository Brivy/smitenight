using Smitenight.Domain.Exceptions;
using Smitenight.Domain.Interfaces;
using Smitenight.Domain.Models.Gods;

namespace Smitenight.Domain.Models.Abilities
{
    public class Ability : IEntity
    {
        public int Id { get; set; }
        public int GodId { get; set; }

        public string Cooldown { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }

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

        public Ability(string cooldown, string cost, string description, string summary, string url)
        {
            Cooldown = cooldown;
            Cost = cost;
            Description = description;
            Summary = summary;
            Url = url;
            AbilityRanks = new List<AbilityRank>();
            AbilityTags = new List<AbilityTag>();
        }
    }
}
