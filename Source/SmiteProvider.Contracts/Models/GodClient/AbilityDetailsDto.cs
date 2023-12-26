using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;

namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

public record class AbilityDetailsDto
{
    public required int Id { get; init; }
    public required string Summary { get; init; }
    public required string Url { get; init; }
    public required string Cooldown { get; init; }
    public required string Cost { get; init; }
    public required string Description { get; init; }
    public required AbilityType AbilityType { get; init; }
    public CommonItemDto[] AbilityTags { get; init; } = [];
    public CommonItemDto[] AbilityRanks { get; init; } = [];
}
