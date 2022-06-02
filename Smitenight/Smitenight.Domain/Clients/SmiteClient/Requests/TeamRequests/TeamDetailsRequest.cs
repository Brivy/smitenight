using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.TeamRequests
{
    public record class TeamDetailsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        int ClanId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.TeamDetailsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(ClanId);
    }
}
