using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.TeamRequests
{
    public record class TeamPlayersRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        int ClanId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.TeamPlayersMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(ClanId);
    }
}
