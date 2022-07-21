using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class PatchInfoRequest(string SessionId) 
        : SmiteClientRequest(MethodNameConstants.PatchInfoMethod, SessionId);
}
