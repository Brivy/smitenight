using Smitenight.Domain.Exceptions;

namespace Smitenight.Domain.Models.Items
{
    public class ItemDescription
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string Description { get; set; }
        public string Value { get; set; }

        #region Navigation

        private Item? _item;

        public Item Item
        {
            get => _item ?? throw new NavigationPropertyNullException(nameof(Item));
            set => _item = value;
        }

        #endregion

        public ItemDescription(string description, string value)
        {
            Description = description;
            Value = value;
        }   
    }
}
