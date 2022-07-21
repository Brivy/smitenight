using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class DemoDetailsRequest(
        string SessionId,
        int MatchId) : SmiteClientRequest(MethodNameConstants.DemoDetailsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
