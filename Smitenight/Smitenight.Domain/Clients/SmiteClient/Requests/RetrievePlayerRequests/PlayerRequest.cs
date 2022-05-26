using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        string PlayerId,
        PortalTypeEnum PortalType) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.PlayerMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId, (int)PortalType);
    }
}
