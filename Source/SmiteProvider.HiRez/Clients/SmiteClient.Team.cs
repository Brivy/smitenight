using Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.TeamClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public partial class SmiteClient
    {
        public async Task<IEnumerable<TeamDetailsDto>> GetTeamDetailsAsync(int clanId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(clanId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TeamDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<TeamDetails>>(url, cancellationToken);
            return _mapperService.MapAll<TeamDetails, TeamDetailsDto>(result);
        }

        public async Task<IEnumerable<TeamPlayerDto>> GetTeamPlayersAsync(int clanId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(clanId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TeamPlayersMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<TeamPlayer>>(url, cancellationToken);
            return _mapperService.MapAll<TeamPlayer, TeamPlayerDto>(result);
        }

        public async Task<IEnumerable<SearchTeamsDto>> SearchTeamsAsync(string teamName, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(teamName);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.SearchTeamsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<SearchTeams>>(url, cancellationToken);
            return _mapperService.MapAll<SearchTeams, SearchTeamsDto>(result);
        }
    }
}
