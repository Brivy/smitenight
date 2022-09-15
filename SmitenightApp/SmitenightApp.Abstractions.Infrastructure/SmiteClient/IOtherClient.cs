using SmitenightApp.Domain.Clients.OtherClient;
using SmitenightApp.Domain.Clients.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IOtherClient
{
    Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(
        CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(
        CancellationToken cancellationToken = default);
}