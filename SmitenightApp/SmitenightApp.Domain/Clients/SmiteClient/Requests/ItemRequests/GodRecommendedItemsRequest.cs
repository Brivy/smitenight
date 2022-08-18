using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.ItemRequests
{
    public record class GodRecommendedItemsRequest(
        int GodId,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(MethodNameConstants.GodRecommendedItemsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(GodId, (int)LanguageCode);
    }
}
