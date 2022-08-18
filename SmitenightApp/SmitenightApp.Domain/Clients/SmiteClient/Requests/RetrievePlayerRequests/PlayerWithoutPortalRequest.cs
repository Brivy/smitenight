using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerWithoutPortalRequest(
        string PlayerName) : SmiteClientRequest(MethodNameConstants.PlayerMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerName);
    }
}
