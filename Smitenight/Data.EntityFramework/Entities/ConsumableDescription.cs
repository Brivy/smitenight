namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class ConsumableDescription
    {
        public int Id { get; set; }
        public int ConsumableId { get; set; }

        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        #region Navigation

        public Consumable? Consumable { get; set; }

        #endregion
    }
}
