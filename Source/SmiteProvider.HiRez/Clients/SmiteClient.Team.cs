using Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.TeamClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients;

public partial class SmiteClient
{
    public async Task<IEnumerable<TeamDetailsDto>> GetTeamDetailsAsync(int clanId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(clanId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TeamDetailsMethod, urlPath, cancellationToken);
        IEnumerable<TeamDetails> result = await GetAsync<IEnumerable<TeamDetails>>(url, cancellationToken);
        return _mapperService.MapAll<TeamDetails, TeamDetailsDto>(result);
    }

    public async Task<IEnumerable<TeamPlayerDto>> GetTeamPlayersAsync(int clanId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(clanId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TeamPlayersMethod, urlPath, cancellationToken);
        IEnumerable<TeamPlayer> result = await GetAsync<IEnumerable<TeamPlayer>>(url, cancellationToken);
        return _mapperService.MapAll<TeamPlayer, TeamPlayerDto>(result);
    }

    public async Task<IEnumerable<SearchTeamsDto>> SearchTeamsAsync(string teamName, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(teamName);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.SearchTeamsMethod, urlPath, cancellationToken);
        IEnumerable<SearchTeams> result = await GetAsync<IEnumerable<SearchTeams>>(url, cancellationToken);
        return _mapperService.MapAll<SearchTeams, SearchTeamsDto>(result);
    }
}
