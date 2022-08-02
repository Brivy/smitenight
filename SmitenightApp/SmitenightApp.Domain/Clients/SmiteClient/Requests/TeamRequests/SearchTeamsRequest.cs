using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.TeamRequests
{
    public record class SearchTeamsRequest(
        string TeamName) : SmiteClientRequest(MethodNameConstants.SearchTeamsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(TeamName);
    }
}
