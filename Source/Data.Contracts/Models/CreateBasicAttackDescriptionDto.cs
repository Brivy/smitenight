namespace Smitenight.Persistence.Data.Contracts.Models
{
    public record CreateBasicAttackDescriptionDto
    {
        public string Checksum { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
