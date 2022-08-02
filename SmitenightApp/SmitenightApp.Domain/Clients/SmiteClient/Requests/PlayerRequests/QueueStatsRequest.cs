using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class QueueStatsRequest(
        string PlayerId,
        GameModeQueueIdEnum GameModeQueueId) : SmiteClientRequest(MethodNameConstants.QueueStatsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId, (int)GameModeQueueId);
    }
}
