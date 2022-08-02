using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodLeaderboardRequest(
        int GodId,
        GameModeQueueIdEnum GameModeQueueId) : SmiteClientRequest(MethodNameConstants.GodLeaderboardMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(GodId, (int)GameModeQueueId);
    }
}
