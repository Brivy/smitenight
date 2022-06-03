using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.OtherRequests
{
    public record class MotdRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.MotdMethod, SessionId);
}
