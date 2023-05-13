using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.LeagueClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class LeagueSmiteClient : SmiteClient, ILeagueSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapperService _mapperService;

        public LeagueSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapperService mapperService) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapperService = mapperService;
        }

        public async Task<IEnumerable<LeagueLeaderboardDto>> GetLeagueLeaderboardAsync(GameModeQueue gameModeQueue, LeagueTier leagueTier, int round, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)gameModeQueue, (int)leagueTier);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.LeagueLeaderbordMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<LeagueLeaderboard>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<LeagueLeaderboard>, IEnumerable<LeagueLeaderboardDto>>(result);
        }

        public async Task<IEnumerable<LeagueSeasonDto>> GetLeagueSeasonsAsync(GameModeQueue gameModeQueue, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)gameModeQueue);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.LeagueSeasonsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<LeagueSeason>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<LeagueSeason>, IEnumerable<LeagueSeasonDto>>(result);
        }
    }
}
