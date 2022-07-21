using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerWithoutPortalRequest(
        string SessionId,
        string PlayerName) : SmiteClientRequest(MethodNameConstants.PlayerMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerName);
    }
}
