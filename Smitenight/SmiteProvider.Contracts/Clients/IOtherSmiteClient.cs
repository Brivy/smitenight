using Smitenight.Domain.Models.Clients.OtherClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IOtherSmiteClient
{
    Task<IEnumerable<EsportProLeague>?> GetEsportProLeagueAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Motd>?> GetMotdAsync(CancellationToken cancellationToken = default);
}