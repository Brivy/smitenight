using AutoMapper;
using Smitenight.Domain.Models.Clients.PlayerClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class PlayerSmiteClient : SmiteClient, IPlayerSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapper _mapper;

        public PlayerSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapper mapper) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Friend>> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.FriendsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<FriendsResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<Friend>>(result);
        }

        public async Task<IEnumerable<GodRank>> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodRanksMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodRanksResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<GodRank>>(result);
        }

        public async Task<PlayerAchievement> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerAchievementsMethod, urlPath, cancellationToken);
            var result = await GetAsync<PlayerAchievementsResponseDto>(url, cancellationToken);
            return _mapper.Map<PlayerAchievement>(result);
        }

        public async Task<IEnumerable<PlayerStatus>> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerStatusMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerStatusResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<PlayerStatus>>(result);
        }

        public async Task<IEnumerable<MatchHistory>> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchHistoryMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchHistoryResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MatchHistory>>(result);
        }

        public async Task<IEnumerable<QueueStats>> GetQueueStatsAsync(string playerId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId, (int)gameModeQueueId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.QueueStatsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<QueueStatsResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<QueueStats>>(result);
        }

        public async Task<IEnumerable<SearchPlayer>> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.SearchPlayersMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<SearchPlayersResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<SearchPlayer>>(result);
        }
    }
}
