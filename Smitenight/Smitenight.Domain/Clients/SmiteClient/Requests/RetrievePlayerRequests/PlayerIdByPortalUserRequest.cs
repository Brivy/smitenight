using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerIdByPortalUserRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        PortalTypeEnum PortalType,
        string PortalUserId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.PlayerIdByPortalUserIdMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)PortalType, PortalUserId);
    }
}
