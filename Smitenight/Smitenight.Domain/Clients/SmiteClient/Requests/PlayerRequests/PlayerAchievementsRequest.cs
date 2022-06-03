using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class PlayerAchievementsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        int PlayerId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.PlayerAchievementsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
