using SmitenightApp.Abstractions.Application.Facades.SmiteClient;
using SmitenightApp.Abstractions.Application.Services.Cache;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.PlayerClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Application.Facades.SmiteClient
{
    /// <summary>
    /// Simplified version without sessionId of <see cref="IPlayerSmiteClient"/>
    /// </summary>
    public class PlayerSmiteClientFacade : IPlayerSmiteClientFacade
    {
        private readonly IPlayerSmiteClient _playerSmiteClient;
        private readonly ISmiteSessionCacheService _smiteSessionCacheService;

        public PlayerSmiteClientFacade(
            IPlayerSmiteClient playerSmiteClient,
            ISmiteSessionCacheService smiteSessionCacheService)
        {
            _playerSmiteClient = playerSmiteClient;
            _smiteSessionCacheService = smiteSessionCacheService;
        }

        public async Task<SmiteClientListResponse<FriendsResponse>?> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default) =>
            await _playerSmiteClient.GetFriendsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), playerId, cancellationToken);

        public async Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default) =>
            await _playerSmiteClient.GetGodRanksAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), playerId, cancellationToken);

        public async Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default) =>
            await _playerSmiteClient.GetPlayerAchievementsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), playerId, cancellationToken);

        public async Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default) =>
            await _playerSmiteClient.GetPlayerStatusAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), playerId, cancellationToken);

        public async Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default) =>
            await _playerSmiteClient.GetMatchHistoryAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), playerId, cancellationToken);

        public async Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(string playerId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default) =>
            await _playerSmiteClient.GetQueueStatsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), playerId, gameModeQueueId, cancellationToken);

        public async Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default) =>
            await _playerSmiteClient.SearchPlayersAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), playerId, cancellationToken);
    }
}
