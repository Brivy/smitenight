using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IPlayerSmiteClient
{
    Task<IEnumerable<FriendDto>> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<GodRankDto>> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default);

    Task<PlayerAchievementDto> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerStatusDto>> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchHistoryDto>> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<QueueStatsDto>> GetQueueStatsAsync(string playerId, GameModeQueue gameModeQueue, CancellationToken cancellationToken = default);

    Task<IEnumerable<SearchPlayerDto>> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default);
}