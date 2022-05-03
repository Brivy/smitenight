namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class CreateSmiteSessionRequest : SmiteClientRequest
    {
        public CreateSmiteSessionRequest(int developerId, string methodName, string responseType, string signature, string currentDate)
            : base(developerId, methodName, responseType, signature, currentDate)
        {

        }
    }
}
