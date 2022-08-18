using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class GodRanksRequest(
        string PlayerId) : SmiteClientRequest(MethodNameConstants.GodRanksMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
