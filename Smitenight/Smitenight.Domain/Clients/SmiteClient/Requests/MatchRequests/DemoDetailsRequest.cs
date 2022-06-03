using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class DemoDetailsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        int MatchId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.DemoDetailsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
