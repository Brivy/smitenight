using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchInfoRequests
{
    public record class MatchIdsByQueueRequest(
        int DeveloperId,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate,
        GameModeQueueIdEnum GameModeQueueId,
        int MatchIdDate,
        int MatchIdHour) : SmiteClientRequest(DeveloperId, MethodNameConstants.MatchIdsByQueueMethod, ResponseType, Signature, SessionId, CurrentDate);
}
