using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerIdByNameRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        string PlayerName) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.PlayerIdByNameMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerName);
    }
}
