using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerIdByNameRequest(
        string PlayerName) : SmiteClientRequest(MethodNameConstants.PlayerIdByNameMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerName);
    }
}
