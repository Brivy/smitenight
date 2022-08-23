namespace SmitenightApp.Domain.Models.Items
{
    public class ItemDescription
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        #region Navigation

        public Item? Item { get; set; }

        #endregion
    }
}
