namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class CreateSmiteSessionRequest(
        int DeveloperId,
        string MethodName,
        string ResponseType,
        string Signature,
        string CurrentDate) : SmiteClientRequest(DeveloperId, MethodName, ResponseType, Signature, CurrentDate);
}
