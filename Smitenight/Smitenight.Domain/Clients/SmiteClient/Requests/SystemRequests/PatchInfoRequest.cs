using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class PatchInfoRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.PatchInfoMethod, SessionId);
}
