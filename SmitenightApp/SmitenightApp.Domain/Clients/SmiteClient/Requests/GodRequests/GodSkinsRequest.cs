using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodSkinsRequest(
        int GodId,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(MethodNameConstants.GodSkinsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(GodId, (int)LanguageCode);
    }
}
