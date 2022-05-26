using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchInfoRequests
{
    public record class TopMatchesRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.TopMatchesMethod, SessionId);
}
