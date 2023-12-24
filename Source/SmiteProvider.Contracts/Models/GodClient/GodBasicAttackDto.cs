using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;

namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

public record class GodBasicAttackDto
{
    public string Cooldown { get; init; } = null!;
    public string Cost { get; init; } = null!;
    public string Description { get; init; } = null!;
    public CommonItemDto[] GodBasicAttackItems { get; init; } = null!;
    public CommonItemDto[] GodBasicAttackRanks { get; init; } = null!;
}
