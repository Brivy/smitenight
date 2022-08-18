using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class DemoDetailsRequest(
        int MatchId) : SmiteClientRequest(MethodNameConstants.DemoDetailsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
