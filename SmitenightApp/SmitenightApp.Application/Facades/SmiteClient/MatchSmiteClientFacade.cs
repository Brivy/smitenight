using SmitenightApp.Abstractions.Application.Facades.SmiteClient;
using SmitenightApp.Abstractions.Application.Services.Cache;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.MatchClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Application.Facades.SmiteClient
{
    /// <summary>
    /// Simplified version without sessionId of <see cref="IMatchSmiteClient"/>
    /// </summary>
    public class MatchSmiteClientFacade : IMatchSmiteClientFacade
    {
        private readonly IMatchSmiteClient _matchSmiteClient;
        private readonly ISmiteSessionCacheService _smiteSessionCacheService;

        public MatchSmiteClientFacade(
            IMatchSmiteClient matchSmiteClient,
            ISmiteSessionCacheService smiteSessionCacheService)
        {
            _matchSmiteClient = matchSmiteClient;
            _smiteSessionCacheService = smiteSessionCacheService;
        }

        public async Task<SmiteClientListResponse<DemoDetailsResponse>?> GetDemoDetailsAsync(int matchId, CancellationToken cancellationToken = default) =>
            await _matchSmiteClient.GetDemoDetailsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), matchId, cancellationToken);

        public async Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsAsync(int matchId, CancellationToken cancellationToken = default) =>
            await _matchSmiteClient.GetMatchDetailsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), matchId, cancellationToken);

        public async Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsBatchAsync(List<int> matchIds, CancellationToken cancellationToken = default) =>
            await _matchSmiteClient.GetMatchDetailsBatchAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), matchIds, cancellationToken);

        public async Task<SmiteClientListResponse<MatchIdsByQueueResponse>?> GetMatchIdsByQueueAsync(GameModeQueueIdEnum gameModeQueueId, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default) =>
            await _matchSmiteClient.GetMatchIdsByQueueAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), gameModeQueueId, matchIdDate, matchIdHour, cancellationToken);

        public async Task<SmiteClientListResponse<MatchPlayersDetailsResponse>?> GetMatchPlayerDetailsAsync(int matchId, CancellationToken cancellationToken = default) =>
            await _matchSmiteClient.GetMatchPlayerDetailsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), matchId, cancellationToken);

        public async Task<SmiteClientListResponse<TopMatchesResponse>?> GetTopMatchesAsync(CancellationToken cancellationToken = default) =>
            await _matchSmiteClient.GetTopMatchesAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), cancellationToken);
    }
}
