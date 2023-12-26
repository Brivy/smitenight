using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;

namespace Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;

public record class ItemDescriptionDto
{
    public required string Description { get; init; }
    public CommonItemDto[] ItemSubDescriptions { get; init; } = [];
    public required string SecondaryDescription { get; init; }
}
