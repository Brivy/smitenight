using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.ItemRequests
{
    public record class GodRecommendedItemsRequest(
        int DeveloperId,
        string MethodName,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate,
        int GodId,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(DeveloperId, MethodName, ResponseType, Signature, SessionId, CurrentDate)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(GodId, (int)LanguageCode);
    }
}
