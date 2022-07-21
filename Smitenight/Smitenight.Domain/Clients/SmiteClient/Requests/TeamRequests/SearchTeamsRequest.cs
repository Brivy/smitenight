using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.TeamRequests
{
    public record class SearchTeamsRequest(
        string SessionId,
        string TeamName) : SmiteClientRequest(MethodNameConstants.SearchTeamsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(TeamName);
    }
}
