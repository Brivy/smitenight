using AutoMapper;
using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class MatchSmiteClient : SmiteClient, IMatchSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapper _mapper;

        public MatchSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapper mapper) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DemoDetailsDto>> GetDemoDetailsAsync(int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.DemoDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<DemoDetails>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<DemoDetailsDto>>(result);
        }

        public async Task<IEnumerable<MatchDetailsDto>> GetMatchDetailsAsync(int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchDetails>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MatchDetailsDto>>(result);
        }

        public async Task<IEnumerable<MatchDetailsDto>> GetMatchDetailsBatchAsync(List<int> matchIds, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(string.Join(',', matchIds));
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchDetailsBatchMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchDetails>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MatchDetailsDto>>(result);
        }

        public async Task<IEnumerable<MatchIdsByQueueDto>> GetMatchIdsByQueueAsync(GameModeQueueIdEnum gameModeQueueId, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)gameModeQueueId, matchIdDate, matchIdHour);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchIdsByQueueMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchIdsByQueue>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MatchIdsByQueueDto>>(result);
        }

        public async Task<IEnumerable<MatchPlayersDetailsDto>> GetMatchPlayerDetailsAsync(int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchPlayerDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchPlayersDetails>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MatchPlayersDetailsDto>>(result);
        }

        public async Task<IEnumerable<TopMatchDto>> GetTopMatchesAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TopMatchesMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<TopMatch>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<TopMatchDto>>(result);
        }
    }
}
