using Smitenight.Domain.Models.Clients.OtherClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IOtherSmiteClient
{
    Task<IEnumerable<EsportProLeagueDto>?> GetEsportProLeagueAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<MotdDto>?> GetMotdAsync(CancellationToken cancellationToken = default);
}