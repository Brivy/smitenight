using AutoMapper;
using Smitenight.Domain.Models.Clients.PlayerClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;
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

        public async Task<IEnumerable<FriendDto>> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.FriendsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<Friend>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<FriendDto>>(result);
        }

        public async Task<IEnumerable<GodRankDto>> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodRanksMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodRank>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<GodRankDto>>(result);
        }

        public async Task<PlayerAchievementDto> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerAchievementsMethod, urlPath, cancellationToken);
            var result = await GetAsync<PlayerAchievement>(url, cancellationToken);
            return _mapper.Map<PlayerAchievementDto>(result);
        }

        public async Task<IEnumerable<PlayerStatusDto>> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerStatusMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerStatus>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<PlayerStatusDto>>(result);
        }

        public async Task<IEnumerable<MatchHistoryDto>> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchHistoryMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchHistory>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MatchHistoryDto>>(result);
        }

        public async Task<IEnumerable<QueueStatsDto>> GetQueueStatsAsync(string playerId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId, (int)gameModeQueueId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.QueueStatsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<QueueStats>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<QueueStatsDto>>(result);
        }

        public async Task<IEnumerable<SearchPlayerDto>> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.SearchPlayersMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<SearchPlayers>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<SearchPlayerDto>>(result);
        }
    }
}
