using SmitenightApp.Domain.Exceptions;

namespace SmitenightApp.Domain.Models.Items
{
    public class ItemDescription
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        #region Navigation

        private Item? _item;

        public Item Item
        {
            get => _item ?? throw new NavigationPropertyNullException(nameof(Item));
            set => _item = value;
        }

        #endregion

        public ItemDescription()
        {

        }   
    }
}
