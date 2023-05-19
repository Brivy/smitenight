using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;

namespace Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient
{
    public record class ItemDescriptionDto
    {
        public string Description { get; init; } = null!;
        public CommonItemDto[] ItemSubDescriptions { get; init; } = null!;
        public string SecondaryDescription { get; init; } = null!;
    }
}
