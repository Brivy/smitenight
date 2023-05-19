namespace Smitenight.Providers.SmiteProvider.Contracts.Models.Common
{
    public record class CommonItemDto
    {
        public string Description { get; init; } = null!;
        public string Value { get; init; } = null!;
    }
}
