using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodsRequest(
        string SessionId,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(MethodNameConstants.GodsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)LanguageCode);
    }
}
