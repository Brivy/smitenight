namespace Smitenight.Persistence.Data.Contracts.Models
{
    public record CreateAbilityTagDto
    {
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
