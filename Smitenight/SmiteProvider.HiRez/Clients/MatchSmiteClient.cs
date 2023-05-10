using AutoMapper;
using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.MatchClient;
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

        public async Task<IEnumerable<DemoDetails>> GetDemoDetailsAsync(int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.DemoDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<DemoDetailsResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<DemoDetails>>(result);
        }

        public async Task<IEnumerable<MatchDetails>> GetMatchDetailsAsync(int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchDetailsResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MatchDetails>>(result);
        }

        public async Task<IEnumerable<MatchDetails>> GetMatchDetailsBatchAsync(List<int> matchIds, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(string.Join(',', matchIds));
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchDetailsBatchMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchDetailsResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MatchDetails>>(result);
        }

        public async Task<IEnumerable<MatchIdsByQueue>> GetMatchIdsByQueueAsync(GameModeQueueIdEnum gameModeQueueId, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)gameModeQueueId, matchIdDate, matchIdHour);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchIdsByQueueMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchIdsByQueueResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MatchIdsByQueue>>(result);
        }

        public async Task<IEnumerable<MatchPlayersDetails>> GetMatchPlayerDetailsAsync(int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchPlayerDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchPlayersDetailsResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MatchPlayersDetails>>(result);
        }

        public async Task<IEnumerable<TopMatch>> GetTopMatchesAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TopMatchesMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<TopMatchesResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<TopMatch>>(result);
        }
    }
}
