namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

public record class GodSkinDto
{
    public required string GodIconUrl { get; init; }
    public required string GodSkinUrl { get; init; }
    public required int GodId { get; init; }
    public required string GodName { get; init; }
    public required string Obtainability { get; init; }
    public required int PriceFavor { get; init; }
    public required int PriceGems { get; init; }
    public string? RetMsg { get; init; }
    public required int SkinId1 { get; init; }
    public required int SkinId2 { get; init; }
    public required string SkinName { get; init; }
}
