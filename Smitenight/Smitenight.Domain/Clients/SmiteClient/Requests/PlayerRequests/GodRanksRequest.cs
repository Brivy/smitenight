using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class GodRanksRequest(
        string SessionId,
        string PlayerId) : SmiteClientRequest(MethodNameConstants.GodRanksMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
