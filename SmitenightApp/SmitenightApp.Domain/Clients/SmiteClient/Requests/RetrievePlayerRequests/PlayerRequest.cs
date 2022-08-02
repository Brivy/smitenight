using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerRequest(
        string PlayerId,
        PortalTypeEnum PortalType) : SmiteClientRequest(MethodNameConstants.PlayerMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId, (int)PortalType);
    }
}
