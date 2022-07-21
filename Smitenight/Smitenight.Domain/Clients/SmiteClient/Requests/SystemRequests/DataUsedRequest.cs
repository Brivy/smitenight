using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class DataUsedRequest(string SessionId) 
        : SmiteClientRequest(MethodNameConstants.DataUsedMethod, SessionId);
}
