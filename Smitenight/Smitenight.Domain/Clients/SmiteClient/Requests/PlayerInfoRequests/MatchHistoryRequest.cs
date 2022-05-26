using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerInfoRequests
{
    public record class MatchHistoryRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        string PlayerId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.MatchHistoryMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
