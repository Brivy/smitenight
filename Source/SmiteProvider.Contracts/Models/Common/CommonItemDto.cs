namespace Smitenight.Providers.SmiteProvider.Contracts.Models.Common;

public record class CommonItemDto
{
    public required string Description { get; init; }
    public required string Value { get; init; }
}
