using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class PlayerAchievementsRequest(
        int PlayerId) : SmiteClientRequest(MethodNameConstants.PlayerAchievementsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
