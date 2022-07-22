using Smitenight.Domain.Exceptions;
using Smitenight.Domain.Interfaces;

namespace Smitenight.Domain.Models.Abilities
{
    public class AbilityRank : IEntity
    {
        public int Id { get; set; }
        public int AbilityId { get; set; }

        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        #region Navigation

        private Ability? _ability;

        public Ability Ability
        {
            get => _ability ?? throw new NavigationPropertyNullException(nameof(Ability));
            set => _ability = value;
        }

        #endregion

        public AbilityRank()
        {

        }
    }
}
