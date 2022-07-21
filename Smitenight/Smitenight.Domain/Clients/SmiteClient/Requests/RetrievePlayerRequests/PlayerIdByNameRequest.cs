using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerIdByNameRequest(
        string SessionId,
        string PlayerName) : SmiteClientRequest(MethodNameConstants.PlayerIdByNameMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerName);
    }
}
