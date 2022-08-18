using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchDetailsBatchRequest(
        List<int> MatchIds) : SmiteClientRequest(MethodNameConstants.MatchDetailsBatchMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(string.Join(',', MatchIds));
    }
}
