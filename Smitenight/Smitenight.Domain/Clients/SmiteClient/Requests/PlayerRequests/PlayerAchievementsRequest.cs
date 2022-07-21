using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class PlayerAchievementsRequest(
        string SessionId,
        int PlayerId) : SmiteClientRequest(MethodNameConstants.PlayerAchievementsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
