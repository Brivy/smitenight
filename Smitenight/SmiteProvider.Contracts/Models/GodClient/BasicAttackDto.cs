using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;

namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient
{
    public record class BasicAttackDto
    {
        public string Cooldown { get; init; } = null!;
        public string Cost { get; init; } = null!;
        public string Description { get; init; } = null!;
        public CommonItemDto[] BasicAttackItems { get; init; } = null!;
        public CommonItemDto[] BasicAttackRanks { get; init; } = null!;
    }
}
