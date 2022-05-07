namespace Smitenight.Domain.Clients.SmiteClient.Responses.GodResponses
{
    public record class GodSkinsResponse(
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