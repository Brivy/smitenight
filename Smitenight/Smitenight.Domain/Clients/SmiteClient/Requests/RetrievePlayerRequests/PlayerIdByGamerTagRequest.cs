using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerIdByGamerTagRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        PortalTypeEnum PortalType,
        string GamerTag) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.PlayerIdByGamerTagMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)PortalType, GamerTag);
    }
}
