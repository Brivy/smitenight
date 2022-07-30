using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodsRequest(
        string SessionId,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(MethodNameConstants.GodsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)LanguageCode);
    }
}
