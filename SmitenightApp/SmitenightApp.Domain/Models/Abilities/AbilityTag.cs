using SmitenightApp.Domain.Exceptions;
using SmitenightApp.Domain.Interfaces;

namespace SmitenightApp.Domain.Models.Abilities
{
    public class AbilityTag : IEntity
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

        public AbilityTag()
        {

        }
    }
}
