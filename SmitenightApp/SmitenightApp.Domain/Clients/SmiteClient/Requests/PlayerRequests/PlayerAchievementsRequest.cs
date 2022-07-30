using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class PlayerAchievementsRequest(
        string SessionId,
        int PlayerId) : SmiteClientRequest(MethodNameConstants.PlayerAchievementsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
