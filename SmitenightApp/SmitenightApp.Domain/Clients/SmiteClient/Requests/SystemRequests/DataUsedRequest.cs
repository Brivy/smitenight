using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class DataUsedRequest() : SmiteClientRequest(MethodNameConstants.DataUsedMethod);
}
