using Smitenight.Domain.Models.Clients.LeagueClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients
{
    public interface ILeagueSmiteClient
    {
        Task<IEnumerable<LeagueLeaderboardDto>> GetLeagueLeaderboardAsync(GameModeQueueIdEnum gameModeQueueId, LeagueTierEnum leagueTier, int round, CancellationToken cancellationToken = default);

        Task<IEnumerable<LeagueSeasonDto>> GetLeagueSeasonsAsync(GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);
    }
}