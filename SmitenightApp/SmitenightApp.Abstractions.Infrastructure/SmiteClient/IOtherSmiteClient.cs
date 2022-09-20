using SmitenightApp.Domain.Clients.OtherClient;
using SmitenightApp.Domain.Clients.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IOtherSmiteClient
{
    Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(
        string sessionId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(
        string sessionId, CancellationToken cancellationToken = default);
}