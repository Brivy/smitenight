using Smitenight.Domain.Models.Clients.PlayerClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IPlayerSmiteClient
{
    Task<IEnumerable<Friend>> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<GodRank>> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default);

    Task<PlayerAchievement> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerStatus>> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchHistory>> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default);

    Task<IEnumerable<QueueStats>> GetQueueStatsAsync(string playerId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);

    Task<IEnumerable<SearchPlayer>> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default);
}