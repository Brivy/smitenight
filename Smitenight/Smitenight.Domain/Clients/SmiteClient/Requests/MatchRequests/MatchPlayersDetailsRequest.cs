using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchPlayersDetailsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        int MatchId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.MatchPlayerDetailsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
