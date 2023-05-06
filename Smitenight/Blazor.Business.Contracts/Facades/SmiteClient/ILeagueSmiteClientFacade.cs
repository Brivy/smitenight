using Smitenight.Domain.Models.Clients.LeagueClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;

public interface ILeagueSmiteClientFacade
{
    Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(GameModeQueueIdEnum gameModeQueueId, LeagueTierEnum leagueTier, int round, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);
}