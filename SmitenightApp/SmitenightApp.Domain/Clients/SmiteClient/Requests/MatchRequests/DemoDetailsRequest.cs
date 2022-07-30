using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class DemoDetailsRequest(
        string SessionId,
        int MatchId) : SmiteClientRequest(MethodNameConstants.DemoDetailsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
