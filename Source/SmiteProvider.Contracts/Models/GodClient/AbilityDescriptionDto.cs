using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;

namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

public record class AbilityDescriptionDto
{
    public required string Cooldown { get; init; }
    public required string Cost { get; init; }
    public required string Description { get; init; }
    public CommonItemDto[] AbilityTags { get; init; } = [];
    public CommonItemDto[] AbilityRanks { get; init; } = [];
}
