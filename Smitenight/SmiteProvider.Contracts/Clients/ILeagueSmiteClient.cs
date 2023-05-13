using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients
{
    public interface ILeagueSmiteClient
    {
        Task<IEnumerable<LeagueLeaderboardDto>> GetLeagueLeaderboardAsync(GameModeQueue gameModeQueue, LeagueTier leagueTier, int round, CancellationToken cancellationToken = default);

        Task<IEnumerable<LeagueSeasonDto>> GetLeagueSeasonsAsync(GameModeQueue gameModeQueue, CancellationToken cancellationToken = default);
    }
}