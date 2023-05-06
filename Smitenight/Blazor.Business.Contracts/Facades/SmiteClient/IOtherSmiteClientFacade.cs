using Smitenight.Domain.Models.Clients.OtherClient;
using Smitenight.Domain.Models.Clients.SmiteClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;

public interface IOtherSmiteClientFacade
{
    Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(CancellationToken cancellationToken = default);
}