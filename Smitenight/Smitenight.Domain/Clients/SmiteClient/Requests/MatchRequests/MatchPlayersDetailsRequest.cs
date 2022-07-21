using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchPlayersDetailsRequest(
        string SessionId,
        int MatchId) : SmiteClientRequest(MethodNameConstants.MatchPlayerDetailsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
