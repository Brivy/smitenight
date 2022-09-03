using SmitenightApp.Domain.Interfaces;

namespace SmitenightApp.Domain.Models.Abilities
{
    public class AbilityRank : IEntity
    {
        public int Id { get; set; }
        public int AbilityId { get; set; }

        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        #region Navigation

        public Ability? Ability { get; set; }

        #endregion
    }
}
