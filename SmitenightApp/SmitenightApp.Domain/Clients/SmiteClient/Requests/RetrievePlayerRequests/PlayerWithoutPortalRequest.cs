using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerWithoutPortalRequest(
        string SessionId,
        string PlayerName) : SmiteClientRequest(MethodNameConstants.PlayerMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerName);
    }
}
