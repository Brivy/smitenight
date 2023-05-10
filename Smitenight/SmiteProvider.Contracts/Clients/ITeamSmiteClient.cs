using Smitenight.Domain.Models.Clients.TeamClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface ITeamSmiteClient
{
    Task<IEnumerable<TeamDetails>> GetTeamDetailsAsync(int clanId, CancellationToken cancellationToken = default);

    Task<IEnumerable<TeamPlayer>> GetTeamPlayersAsync(int clanId, CancellationToken cancellationToken = default);

    Task<IEnumerable<SearchTeams>> SearchTeamsAsync(string teamName, CancellationToken cancellationToken = default);
}