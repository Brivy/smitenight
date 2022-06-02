using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.TeamRequests
{
    public record class SearchTeamsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        string TeamName) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.SearchTeamsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(TeamName);
    }
}
