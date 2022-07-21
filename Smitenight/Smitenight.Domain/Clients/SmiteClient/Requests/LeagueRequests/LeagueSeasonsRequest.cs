using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.LeagueRequests
{
    public record class LeagueSeasonsRequest(
        string SessionId,
        GameModeQueueIdEnum GameModeQueueId) : SmiteClientRequest(MethodNameConstants.LeagueSeasonsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)GameModeQueueId);
    }
}
