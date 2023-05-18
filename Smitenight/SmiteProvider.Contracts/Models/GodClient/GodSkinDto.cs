namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient
{
    public record class GodSkinDto
    {
        public string GodIconUrl { get; init; } = null!;
        public string GodSkinUrl { get; init; } = null!;
        public int GodId { get; init; }
        public string GodName { get; init; } = null!;
        public string Obtainability { get; init; } = null!;
        public int PriceFavor { get; init; }
        public int PriceGems { get; init; }
        public string? RetMsg { get; init; }
        public int SkinId1 { get; init; }
        public int SkinId2 { get; init; }
        public string SkinName { get; init; } = null!;
    }

}