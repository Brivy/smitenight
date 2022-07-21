using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class QueueStatsRequest(
        string SessionId,
        string PlayerId,
        GameModeQueueIdEnum GameModeQueueId) : SmiteClientRequest(MethodNameConstants.QueueStatsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId, (int)GameModeQueueId);
    }
}
