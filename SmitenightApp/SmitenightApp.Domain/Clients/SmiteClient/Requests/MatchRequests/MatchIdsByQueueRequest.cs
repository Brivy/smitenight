using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchIdsByQueueRequest(
        GameModeQueueIdEnum GameModeQueueId,
        int MatchIdDate,
        int MatchIdHour) : SmiteClientRequest(MethodNameConstants.MatchIdsByQueueMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)GameModeQueueId, MatchIdDate, MatchIdHour);
    }
}
