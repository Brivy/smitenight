using Smitenight.Domain.Clients.SmiteClient.Requests.PlayerInfoRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.PlayerInfoResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface IPlayerInfoClient
{
    Task<SmiteClientListResponse<FriendsResponse>?> GetFriendsAsync(
        FriendsRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(
        GodRanksRequest request, CancellationToken cancellationToken);

    Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(
        PlayerAchievementsRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(
        PlayerStatusRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(
        MatchHistoryRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(
        QueueStatsRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(
        SearchPlayersRequest request, CancellationToken cancellationToken);
}