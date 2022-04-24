using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;

namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

public record class AbilityDetailsDto
{
    public int Id { get; init; }
    public string Summary { get; init; } = null!;
    public string Url { get; init; } = null!;
    public string Cooldown { get; init; } = null!;
    public string Cost { get; init; } = null!;
    public string Description { get; init; } = null!;
    public AbilityType AbilityType { get; init; }
    public CommonItemDto[] AbilityTags { get; init; } = null!;
    public CommonItemDto[] AbilityRanks { get; init; } = null!;
}
