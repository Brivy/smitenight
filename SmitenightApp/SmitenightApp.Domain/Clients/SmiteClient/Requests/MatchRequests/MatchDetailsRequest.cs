using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchDetailsRequest(
        int MatchId) : SmiteClientRequest(MethodNameConstants.MatchDetailsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
