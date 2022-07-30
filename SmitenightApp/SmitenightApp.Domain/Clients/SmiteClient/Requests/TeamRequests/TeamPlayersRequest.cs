using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.TeamRequests
{
    public record class TeamPlayersRequest(
        string SessionId,
        int ClanId) : SmiteClientRequest(MethodNameConstants.TeamPlayersMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(ClanId);
    }
}
