namespace SmitenightApp.Domain.Contracts.Items
{
    public class ConsumableDto
    {
        public bool Enabled { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? SecondaryDescription { get; set; }
        public string? ShortDescription { get; set; }
        public string ItemIconUrl { get; set; } = null!;

        public List<ConsumableDescriptionDto> ConsumableDescriptions { get; set; }

        public ConsumableDto()
        {
            ConsumableDescriptions = new List<ConsumableDescriptionDto>();
        }
    }
}
