using Smitenight.Domain.Models.Clients.PlayerClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

public interface IPlayerSmiteClient
{
    Task<SmiteClientListResponse<FriendsResponse>?> GetFriendsAsync(
        string sessionId, string playerId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(
        string sessionId, string playerId, CancellationToken cancellationToken = default);

    Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(
        string sessionId, int playerId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(
        string sessionId, string playerId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(
        string sessionId, string playerId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(
        string sessionId, string playerId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(
        string sessionId, string playerId, CancellationToken cancellationToken = default);
}