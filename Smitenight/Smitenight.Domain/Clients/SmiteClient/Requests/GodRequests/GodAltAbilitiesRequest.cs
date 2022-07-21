using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodAltAbilitiesRequest(string SessionId) 
        : SmiteClientRequest(MethodNameConstants.GodAltAbilitiesMethod, SessionId);
}
