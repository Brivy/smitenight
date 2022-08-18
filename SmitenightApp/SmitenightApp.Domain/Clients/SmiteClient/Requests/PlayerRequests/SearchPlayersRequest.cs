using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class SearchPlayersRequest(
        string PlayerId) : SmiteClientRequest(MethodNameConstants.SearchPlayersMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
