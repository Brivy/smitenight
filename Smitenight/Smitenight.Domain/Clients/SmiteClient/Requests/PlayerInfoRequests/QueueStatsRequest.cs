using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerInfoRequests
{
    public record class QueueStatsRequest(
        int DeveloperId,
        string MethodName,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate,
        string PlayerId,
        GameModeQueueIdEnum GameModeQueueId) : SmiteClientRequest(DeveloperId, MethodName, ResponseType, Signature, SessionId, CurrentDate)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId, (int)GameModeQueueId);
    }
}
