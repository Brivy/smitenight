using Smitenight.Domain.Models.Clients.OtherClient;
using Smitenight.Domain.Models.Clients.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

public interface IOtherSmiteClient
{
    Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(
        string sessionId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(
        string sessionId, CancellationToken cancellationToken = default);
}