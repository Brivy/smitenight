namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient
{
    public record class GodAltAbilityDto
    {
        public string AltName { get; init; } = null!;
        public string AltPosition { get; init; } = null!;
        public string God { get; init; } = null!;
        public int GodId { get; init; }
        public int ItemId { get; init; }
        public string? RetMsg { get; init; }
    }
}
