using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerIdByPortalUserRequest(
        string SessionId,
        PortalTypeEnum PortalType,
        string PortalUserId) : SmiteClientRequest(MethodNameConstants.PlayerIdByPortalUserIdMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)PortalType, PortalUserId);
    }
}
