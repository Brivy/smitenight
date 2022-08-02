using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class CreateSmiteSessionRequest() 
        : SmiteClientRequest(MethodNameConstants.CreateSessionMethod, false);
}
