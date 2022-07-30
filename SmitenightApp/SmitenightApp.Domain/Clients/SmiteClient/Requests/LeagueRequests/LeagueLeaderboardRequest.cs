using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.LeagueRequests
{
    public record class LeagueLeaderboardRequest(
        string SessionId,
        GameModeQueueIdEnum GameModeQueueId,
        LeagueTierEnum LeagueTier,
        int Round) : SmiteClientRequest(MethodNameConstants.LeagueLeaderbordMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)GameModeQueueId, (int)LeagueTier, Round);
    }
}
