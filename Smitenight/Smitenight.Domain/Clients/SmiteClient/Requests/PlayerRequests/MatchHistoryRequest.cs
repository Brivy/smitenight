using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class MatchHistoryRequest(
        string SessionId,
        string PlayerId) : SmiteClientRequest(MethodNameConstants.MatchHistoryMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
