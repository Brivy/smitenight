using SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.PlayerResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

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