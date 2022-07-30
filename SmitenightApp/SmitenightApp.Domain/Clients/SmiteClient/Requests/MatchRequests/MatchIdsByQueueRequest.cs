using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchIdsByQueueRequest(
        string SessionId,
        GameModeQueueIdEnum GameModeQueueId,
        int MatchIdDate,
        int MatchIdHour) : SmiteClientRequest(MethodNameConstants.MatchIdsByQueueMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)GameModeQueueId, MatchIdDate, MatchIdHour);
    }
}
