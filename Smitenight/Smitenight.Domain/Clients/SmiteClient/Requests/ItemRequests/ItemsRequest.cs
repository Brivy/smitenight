using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.ItemRequests
{
    public record class ItemsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.ItemsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)LanguageCode);
    }
}
