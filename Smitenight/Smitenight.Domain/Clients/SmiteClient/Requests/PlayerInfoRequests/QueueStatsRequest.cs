using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerInfoRequests
{
    public record class QueueStatsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        string PlayerId,
        GameModeQueueIdEnum GameModeQueueId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.QueueStatsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId, (int)GameModeQueueId);
    }
}
