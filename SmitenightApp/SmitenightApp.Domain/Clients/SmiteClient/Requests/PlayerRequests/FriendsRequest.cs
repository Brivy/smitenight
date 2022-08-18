using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class FriendsRequest(
        string PlayerId) : SmiteClientRequest(MethodNameConstants.FriendsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
