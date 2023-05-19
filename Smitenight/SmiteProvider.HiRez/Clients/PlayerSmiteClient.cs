using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class PlayerSmiteClient : SmiteClient, IPlayerSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapperService _mapperService;

        public PlayerSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapperService mapperService) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapperService = mapperService;
        }

        public async Task<IEnumerable<FriendDto>> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.FriendsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<Friend>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<Friend>, IEnumerable<FriendDto>>(result);
        }

        public async Task<IEnumerable<GodRankDto>> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodRanksMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodRank>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<GodRank>, IEnumerable<GodRankDto>>(result);
        }

        public async Task<PlayerAchievementDto> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerAchievementsMethod, urlPath, cancellationToken);
            var result = await GetAsync<PlayerAchievement>(url, cancellationToken);
            return _mapperService.Map<PlayerAchievement, PlayerAchievementDto>(result);
        }

        public async Task<IEnumerable<PlayerStatusDto>> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerStatusMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerStatus>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<PlayerStatus>, IEnumerable<PlayerStatusDto>>(result);
        }

        public async Task<IEnumerable<MatchHistoryDto>> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchHistoryMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchHistory>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<MatchHistory>, IEnumerable<MatchHistoryDto>>(result);
        }

        public async Task<IEnumerable<QueueStatsDto>> GetQueueStatsAsync(string playerId, GameModeQueue gameModeQueue, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId, (int)gameModeQueue);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.QueueStatsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<QueueStats>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<QueueStats>, IEnumerable<QueueStatsDto>>(result);
        }

        public async Task<IEnumerable<SearchPlayerDto>> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.SearchPlayersMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<SearchPlayer>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<SearchPlayer>, IEnumerable<SearchPlayerDto>>(result);
        }
    }
}
