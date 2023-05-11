using Smitenight.Domain.Models.Clients.PlayerClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IPlayerSmiteClient
{
    Task<IEnumerable<FriendDto>> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<GodRankDto>> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default);

    Task<PlayerAchievementDto> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerStatusDto>> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchHistoryDto>> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<QueueStatsDto>> GetQueueStatsAsync(string playerId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);

    Task<IEnumerable<SearchPlayerDto>> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default);
}