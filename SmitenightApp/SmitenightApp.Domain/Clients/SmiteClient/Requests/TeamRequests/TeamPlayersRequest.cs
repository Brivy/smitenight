using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.TeamRequests
{
    public record class TeamPlayersRequest(
        int ClanId) : SmiteClientRequest(MethodNameConstants.TeamPlayersMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(ClanId);
    }
}
