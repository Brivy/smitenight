namespace Smitenight.Persistence.Data.Contracts.Models
{
    public record CreateBasicAttackDescriptionDto
    {
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
