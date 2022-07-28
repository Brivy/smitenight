using Smitenight.Domain.Interfaces;

namespace Smitenight.Domain.Models.Items
{
    public class Consumable : IEntity
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }

        public bool Enabled { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? SecondaryDescription { get; set; }
        public string? ShortDescription { get; set; }
        public string ItemIconUrl { get; set; } = null!;

        #region Navigation

        public List<ConsumableDescription> ConsumableDescriptions { get; set; }

        #endregion

        public Consumable()
        {
            ConsumableDescriptions = new List<ConsumableDescription>();
        }
    }
}
