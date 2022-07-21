using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerRequest(
        string SessionId,
        string PlayerId,
        PortalTypeEnum PortalType) : SmiteClientRequest(MethodNameConstants.PlayerMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId, (int)PortalType);
    }
}
