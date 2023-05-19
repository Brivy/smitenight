using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;

namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient
{
    public record class AbilityDescriptionDto
    {
        public string Cooldown { get; init; } = null!;
        public string Cost { get; init; } = null!;
        public string Description { get; init; } = null!;
        public CommonItemDto[] AbilityTags { get; init; } = null!;
        public CommonItemDto[] AbilityRanks { get; init; } = null!;
    }
}
