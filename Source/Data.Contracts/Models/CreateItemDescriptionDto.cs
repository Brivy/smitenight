namespace Smitenight.Persistence.Data.Contracts.Models;

public record CreateItemDescriptionDto
{
    public string Description { get; set; } = null!;
    public string Value { get; set; } = null!;
}
