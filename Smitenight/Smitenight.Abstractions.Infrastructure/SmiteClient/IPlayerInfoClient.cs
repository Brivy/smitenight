using Smitenight.Domain.Clients.SmiteClient.Requests.PlayerInfoRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.PlayerInfoResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface IPlayerInfoClient
{
    Task<SmiteClientListResponse<FriendsResponse>?> GetFriendsAsync(
        FriendsRequest friendsRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(
        GodRanksRequest godRanksRequest, CancellationToken cancellationToken);

    Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(
        PlayerAchievementsRequest playerAchievementsRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(
        PlayerStatusRequest playerStatusRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(
        MatchHistoryRequest matchHistoryRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(
        QueueStatsRequest queueStatsRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(
        SearchPlayersRequest searchPlayersRequest, CancellationToken cancellationToken);
}