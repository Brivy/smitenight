using SmitenightApp.Domain.Exceptions;
using SmitenightApp.Domain.Interfaces;

namespace SmitenightApp.Domain.Models.Gods
{
    public class BasicAttackDescription : IEntity
    {
        public int Id { get; set; }
        public int GodId { get; set; }

        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        #region Navigation

        private God? _god;

        public God God
        {
            get => _god ?? throw new NavigationPropertyNullException(nameof(God));
            set => _god = value;
        }

        #endregion

        public BasicAttackDescription()
        {

        }
    }
}
