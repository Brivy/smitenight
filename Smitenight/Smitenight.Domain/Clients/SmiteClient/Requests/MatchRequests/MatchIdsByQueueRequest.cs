using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchIdsByQueueRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        GameModeQueueIdEnum GameModeQueueId,
        int MatchIdDate,
        int MatchIdHour) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.MatchIdsByQueueMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)GameModeQueueId, MatchIdDate, MatchIdHour);
    }
}
