using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerIdByGamerTagRequest(
        PortalTypeEnum PortalType,
        string GamerTag) : SmiteClientRequest(MethodNameConstants.PlayerIdByGamerTagMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)PortalType, GamerTag);
    }
}
