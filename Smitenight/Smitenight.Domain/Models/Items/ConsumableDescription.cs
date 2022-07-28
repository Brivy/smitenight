using Smitenight.Domain.Exceptions;

namespace Smitenight.Domain.Models.Items
{
    public class ConsumableDescription
    {
        public int Id { get; set; }
        public int ConsumableId { get; set; }

        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        #region Navigation

        private Consumable? _consumable;

        public Consumable Consumable
        {
            get => _consumable ?? throw new NavigationPropertyNullException(nameof(Consumable));
            set => _consumable = value;
        }

        #endregion

        public ConsumableDescription()
        {

        }   
    }
}
