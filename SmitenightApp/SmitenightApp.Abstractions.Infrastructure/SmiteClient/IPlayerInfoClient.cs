using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.PlayerResponses;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IPlayerInfoClient
{
    Task<SmiteClientListResponse<FriendsResponse>?> GetFriendsAsync(
        string sessionId, string playerId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(
        string sessionId, string playerId, CancellationToken cancellationToken);

    Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(
        string sessionId, int playerId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(
        string sessionId, string playerId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(
        string sessionId, string playerId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(
        string sessionId, string playerId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(
        string sessionId, string playerId, CancellationToken cancellationToken);
}