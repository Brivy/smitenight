using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class CreateSmiteSessionRequest(
        int DeveloperId,
        string AuthenticationKey) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.CreateSessionMethod);
}
