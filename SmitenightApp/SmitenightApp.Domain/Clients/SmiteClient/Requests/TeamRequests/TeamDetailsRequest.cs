using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.TeamRequests
{
    public record class TeamDetailsRequest(
        int ClanId) : SmiteClientRequest(MethodNameConstants.TeamDetailsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(ClanId);
    }
}
