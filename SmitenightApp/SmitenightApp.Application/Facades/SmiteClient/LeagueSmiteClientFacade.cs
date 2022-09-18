using SmitenightApp.Abstractions.Application.Facades.SmiteClient;
using SmitenightApp.Abstractions.Application.Services.Cache;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.LeagueClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Application.Facades.SmiteClient
{
    /// <summary>
    /// Simplified version without sessionId of <see cref="ILeagueSmiteClient"/>
    /// </summary>
    public class LeagueSmiteClientFacade : ILeagueSmiteClientFacade
    {
        private readonly ILeagueSmiteClient _leagueSmiteClient;
        private readonly ISmiteSessionCacheService _smiteSessionCacheService;

        public LeagueSmiteClientFacade(
            ILeagueSmiteClient leagueSmiteClient,
            ISmiteSessionCacheService smiteSessionCacheService)
        {
            _leagueSmiteClient = leagueSmiteClient;
            _smiteSessionCacheService = smiteSessionCacheService;
        }

        public async Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(GameModeQueueIdEnum gameModeQueueId, LeagueTierEnum leagueTier, int round, CancellationToken cancellationToken = default) =>
            await _leagueSmiteClient.GetLeagueLeaderboardAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), gameModeQueueId, leagueTier, round, cancellationToken);

        public async Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default) =>
            await _leagueSmiteClient.GetLeagueSeasonsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), gameModeQueueId, cancellationToken);
    }
}
