using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.ItemRequests
{
    public record class GodRecommendedItemsRequest(
        string SessionId,
        int GodId,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(MethodNameConstants.GodRecommendedItemsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(GodId, (int)LanguageCode);
    }
}
