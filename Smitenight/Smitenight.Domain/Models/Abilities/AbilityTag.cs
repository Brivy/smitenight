using Smitenight.Domain.Exceptions;
using Smitenight.Domain.Interfaces;

namespace Smitenight.Domain.Models.Abilities
{
    public class AbilityTag : IEntity
    {
        public int Id { get; set; }
        public int AbilityId { get; set; }

        public string Description { get; set; }
        public string Value { get; set; }

        #region Navigation

        private Ability? _ability;

        public Ability Ability
        {
            get => _ability ?? throw new NavigationPropertyNullException(nameof(Ability));
            set => _ability = value;
        }

        #endregion

        public AbilityTag(string description, string value)
        {
            Description = description;
            Value = value;
        }
    }
}
