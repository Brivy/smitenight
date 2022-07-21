using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class TopMatchesRequest(string SessionId) 
        : SmiteClientRequest(MethodNameConstants.TopMatchesMethod, SessionId);
}
