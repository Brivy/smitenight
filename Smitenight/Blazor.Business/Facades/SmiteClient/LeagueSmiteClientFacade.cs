using Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;
using Smitenight.Application.Blazor.Business.Contracts.Services.Cache;
using Smitenight.Domain.Models.Clients.LeagueClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

namespace Smitenight.Application.Blazor.Business.Facades.SmiteClient
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
