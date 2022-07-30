using SmitenightApp.Domain.Enums.Items;
using SmitenightApp.Domain.Exceptions;
using SmitenightApp.Domain.Interfaces;

namespace SmitenightApp.Domain.Models.Items
{
    public class Active : IEntity
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }
        public int? RootActiveId { get; set; }
        public int? ChildActiveId { get; set; }

        public bool Enabled { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ItemTierEnum ItemTier { get; set; }
        public int Price { get; set; }
        public string SecondaryDescription { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string ItemIconUrl { get; set; } = null!;

        #region Navigation

        private Active? _rootActive;
        private Active? _childActive;

        public Active RootActive
        {
            get => _rootActive ?? throw new NavigationPropertyNullException(nameof(RootActive));
            set => _rootActive = value;
        }

        public Active ChildActive
        {
            get => _childActive ?? throw new NavigationPropertyNullException(nameof(ChildActive));
            set => _childActive = value;
        }

        public List<ActivePurchase> ActivePurchases { get; set; }

        #endregion

        public Active()
        {
            ActivePurchases = new List<ActivePurchase>();
        }
    }
}
