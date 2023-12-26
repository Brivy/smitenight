namespace Smitenight.Persistence.Data.Contracts.Models;

public record CreateItemDescriptionDto
{
    public required string Description { get; init; }
    public required string Value { get; init; }
}
