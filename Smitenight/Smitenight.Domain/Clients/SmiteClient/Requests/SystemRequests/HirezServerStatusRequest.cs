namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class HirezServerStatusRequest(
        int DeveloperId,
        string MethodName,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate) : SmiteClientRequest(DeveloperId, MethodName, ResponseType, Signature, SessionId, CurrentDate);
}
