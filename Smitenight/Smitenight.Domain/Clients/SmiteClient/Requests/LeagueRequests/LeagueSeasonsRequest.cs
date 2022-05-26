using Smitenight.Domain.Constants.SmiteClient;
using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.LeagueRequests
{
    public record class LeagueSeasonsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        GameModeQueueIdEnum GameModeQueueId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.LeagueSeasonsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)GameModeQueueId);
    }
}
