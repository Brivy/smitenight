using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.LeagueRequests
{
    public record class LeagueSeasonsRequest(
        GameModeQueueIdEnum GameModeQueueId) : SmiteClientRequest(MethodNameConstants.LeagueSeasonsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)GameModeQueueId);
    }
}
