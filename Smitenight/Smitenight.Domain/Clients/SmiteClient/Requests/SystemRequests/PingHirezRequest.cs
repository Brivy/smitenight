namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class PingHirezRequest(
        string MethodName, 
        string ResponseType) : SmiteClientRequest(MethodName, ResponseType);
}
