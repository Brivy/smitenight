using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodAltAbilitiesRequest() : SmiteClientRequest(MethodNameConstants.GodAltAbilitiesMethod);
}
