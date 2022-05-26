using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.GodsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)LanguageCode);
    }
}
