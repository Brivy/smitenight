using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.GodRequests
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
