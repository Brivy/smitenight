namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient
{
    public record class GodSkinDto(
        string GodIconUrl,
        string GodSkinUrl,
        int GodId,
        string GodName,
        string Obtainability,
        int PriceFavor,
        int PriceGems,
        object RetMsg,
        int SkinId1,
        int SkinId2,
        string SkinName
    );
}