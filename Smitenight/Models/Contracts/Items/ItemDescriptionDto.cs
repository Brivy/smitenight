namespace Smitenight.Domain.Models.Contracts.Items
{
    public class ItemDescriptionDto
    {
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        public ItemDto? Item { get; set; }
    }
}
