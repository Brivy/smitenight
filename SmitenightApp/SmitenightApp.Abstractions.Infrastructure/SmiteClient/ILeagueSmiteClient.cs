using SmitenightApp.Domain.Clients.LeagueClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient
{
    public interface ILeagueSmiteClient
    {
        Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(
            string sessionId, GameModeQueueIdEnum gameModeQueueId, LeagueTierEnum leagueTier, int round, CancellationToken cancellationToken = default);

        Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(
            string sessionId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);
    }
}