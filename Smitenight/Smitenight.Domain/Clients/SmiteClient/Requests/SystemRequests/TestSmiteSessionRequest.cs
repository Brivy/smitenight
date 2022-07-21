using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class TestSmiteSessionRequest(string SessionId) 
        : SmiteClientRequest(MethodNameConstants.TestSessionMethod, SessionId);
}
