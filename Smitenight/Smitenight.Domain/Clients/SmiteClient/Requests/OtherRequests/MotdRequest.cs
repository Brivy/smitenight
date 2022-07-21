using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.OtherRequests
{
    public record class MotdRequest(string SessionId) 
        : SmiteClientRequest(MethodNameConstants.MotdMethod, SessionId);
}
