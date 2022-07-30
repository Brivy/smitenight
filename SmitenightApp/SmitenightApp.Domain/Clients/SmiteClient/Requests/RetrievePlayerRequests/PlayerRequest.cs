using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
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
