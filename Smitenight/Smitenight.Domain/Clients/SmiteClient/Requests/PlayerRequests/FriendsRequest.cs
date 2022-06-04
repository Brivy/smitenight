using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class FriendsRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        string PlayerId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.FriendsMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
