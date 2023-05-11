using Smitenight.Domain.Models.Clients.TeamClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface ITeamSmiteClient
{
    Task<IEnumerable<TeamDetailsDto>> GetTeamDetailsAsync(int clanId, CancellationToken cancellationToken = default);

    Task<IEnumerable<TeamPlayerDto>> GetTeamPlayersAsync(int clanId, CancellationToken cancellationToken = default);

    Task<IEnumerable<SearchTeamsDto>> SearchTeamsAsync(string teamName, CancellationToken cancellationToken = default);
}