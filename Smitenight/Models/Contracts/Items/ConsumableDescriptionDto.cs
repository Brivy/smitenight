namespace Smitenight.Domain.Models.Contracts.Items
{
    public class ConsumableDescriptionDto
    {
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        public ConsumableDto? Consumable { get; set; }
    }
}
