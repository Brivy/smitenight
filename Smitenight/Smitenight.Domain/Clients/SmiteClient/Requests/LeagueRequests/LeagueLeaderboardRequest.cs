using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.LeagueRequests
{
    public record class LeagueLeaderboardRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        GameModeQueueIdEnum GameModeQueueId,
        LeagueTierEnum LeagueTier,
        int Round) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.LeagueLeaderbordMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)GameModeQueueId, (int)LeagueTier, Round);
    }
}
