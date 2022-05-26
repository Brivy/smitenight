using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class PingHirezRequest() 
        : SmiteClientRequest(MethodNameConstants.PingMethod);
}
