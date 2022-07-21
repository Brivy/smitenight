using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchDetailsRequest(
        string SessionId,
        int MatchId) : SmiteClientRequest(MethodNameConstants.MatchDetailsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
