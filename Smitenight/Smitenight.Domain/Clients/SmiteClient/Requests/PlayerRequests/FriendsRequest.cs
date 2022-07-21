using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class FriendsRequest(
        string SessionId,
        string PlayerId) : SmiteClientRequest(MethodNameConstants.FriendsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
