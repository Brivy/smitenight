using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.LeagueClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients;

public partial class SmiteClient
{
    public async Task<IEnumerable<LeagueLeaderboardDto>> GetLeagueLeaderboardAsync(GameModeQueue gameModeQueue, LeagueTier leagueTier, int round, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath((int)gameModeQueue, (int)leagueTier);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.LeagueLeaderbordMethod, urlPath, cancellationToken);
        IEnumerable<LeagueLeaderboard> result = await GetAsync<IEnumerable<LeagueLeaderboard>>(url, cancellationToken);
        return _mapperService.MapAll<LeagueLeaderboard, LeagueLeaderboardDto>(result);
    }

    public async Task<IEnumerable<LeagueSeasonDto>> GetLeagueSeasonsAsync(GameModeQueue gameModeQueue, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath((int)gameModeQueue);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.LeagueSeasonsMethod, urlPath, cancellationToken);
        IEnumerable<LeagueSeason> result = await GetAsync<IEnumerable<LeagueSeason>>(url, cancellationToken);
        return _mapperService.MapAll<LeagueSeason, LeagueSeasonDto>(result);
    }
}
