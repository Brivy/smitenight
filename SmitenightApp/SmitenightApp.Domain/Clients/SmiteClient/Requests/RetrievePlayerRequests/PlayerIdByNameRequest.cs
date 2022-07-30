using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerIdByNameRequest(
        string SessionId,
        string PlayerName) : SmiteClientRequest(MethodNameConstants.PlayerIdByNameMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerName);
    }
}
