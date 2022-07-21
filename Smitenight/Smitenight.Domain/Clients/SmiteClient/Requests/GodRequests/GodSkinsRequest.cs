using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodSkinsRequest(
        string SessionId,
        int GodId,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(MethodNameConstants.GodSkinsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(GodId, (int)LanguageCode);
    }
}
