using SmitenightApp.Domain.Clients.LeagueClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Application.Facades.SmiteClient;

public interface ILeagueSmiteClientFacade
{
    Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(GameModeQueueIdEnum gameModeQueueId, LeagueTierEnum leagueTier, int round, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);
}