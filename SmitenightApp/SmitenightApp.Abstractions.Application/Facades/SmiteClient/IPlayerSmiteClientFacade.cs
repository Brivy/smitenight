using SmitenightApp.Domain.Clients.PlayerClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Application.Facades.SmiteClient;

public interface IPlayerSmiteClientFacade
{
    Task<SmiteClientListResponse<FriendsResponse>?> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default);
    Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(string playerId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default);
}