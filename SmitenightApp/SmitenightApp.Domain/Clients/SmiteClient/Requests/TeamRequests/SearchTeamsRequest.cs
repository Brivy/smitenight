using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.TeamRequests
{
    public record class SearchTeamsRequest(
        string SessionId,
        string TeamName) : SmiteClientRequest(MethodNameConstants.SearchTeamsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(TeamName);
    }
}
