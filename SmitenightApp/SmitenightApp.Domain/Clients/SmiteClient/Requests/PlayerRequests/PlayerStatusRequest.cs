using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class PlayerStatusRequest(
        string PlayerId) : SmiteClientRequest(MethodNameConstants.PlayerStatusMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
