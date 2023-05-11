using AutoMapper;
using Smitenight.Domain.Models.Clients.LeagueClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Models.LeagueClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class LeagueSmiteClient : SmiteClient, ILeagueSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapper _mapper;

        public LeagueSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapper mapper) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeagueLeaderboardDto>> GetLeagueLeaderboardAsync(GameModeQueueIdEnum gameModeQueueId, LeagueTierEnum leagueTier, int round, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)gameModeQueueId, (int)leagueTier);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.LeagueLeaderbordMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<LeagueLeaderboard>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<LeagueLeaderboardDto>>(result);
        }

        public async Task<IEnumerable<LeagueSeasonDto>> GetLeagueSeasonsAsync(GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)gameModeQueueId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.LeagueSeasonsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<LeagueSeason>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<LeagueSeasonDto>>(result);
        }
    }
}
