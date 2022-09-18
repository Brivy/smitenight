using SmitenightApp.Domain.Clients.OtherClient;
using SmitenightApp.Domain.Clients.SmiteClient;

namespace SmitenightApp.Abstractions.Application.Facades.SmiteClient;

public interface IOtherSmiteClientFacade
{
    Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(CancellationToken cancellationToken = default);
}