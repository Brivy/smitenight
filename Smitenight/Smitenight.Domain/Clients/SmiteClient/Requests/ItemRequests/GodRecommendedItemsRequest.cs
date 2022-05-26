using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.ItemRequests
{
    public record class GodRecommendedItemsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        int GodId,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.GodRecommendedItemsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(GodId, (int)LanguageCode);
    }
}
