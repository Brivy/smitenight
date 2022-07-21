using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodLeaderboardRequest(
        string SessionId,
        int GodId,
        GameModeQueueIdEnum GameModeQueueId) : SmiteClientRequest(MethodNameConstants.GodLeaderboardMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(GodId, (int)GameModeQueueId);
    }
}
