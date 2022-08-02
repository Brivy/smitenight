using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchPlayersDetailsRequest(
        int MatchId) : SmiteClientRequest(MethodNameConstants.MatchPlayerDetailsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
