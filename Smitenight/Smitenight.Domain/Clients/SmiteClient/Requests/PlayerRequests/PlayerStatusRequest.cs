using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class PlayerStatusRequest(
        string SessionId,
        string PlayerId) : SmiteClientRequest(MethodNameConstants.PlayerStatusMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
