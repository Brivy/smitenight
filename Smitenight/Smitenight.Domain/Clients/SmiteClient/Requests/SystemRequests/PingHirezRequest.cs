namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class PingHirezRequest : SmiteClientRequest
    {
        public PingHirezRequest(string methodName, string responseType) : base(methodName, responseType)
        {

        }
    }
}
