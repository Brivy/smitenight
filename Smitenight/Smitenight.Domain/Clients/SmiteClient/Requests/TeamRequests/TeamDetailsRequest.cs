using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.TeamRequests
{
    public record class TeamDetailsRequest(
        string SessionId,
        int ClanId) : SmiteClientRequest(MethodNameConstants.TeamDetailsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(ClanId);
    }
}
