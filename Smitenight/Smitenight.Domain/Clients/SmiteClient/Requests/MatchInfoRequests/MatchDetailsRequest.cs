using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchInfoRequests
{
    public record class MatchDetailsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        int MatchId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.MatchDetailsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
