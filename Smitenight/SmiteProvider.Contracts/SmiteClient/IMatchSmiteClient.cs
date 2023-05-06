using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

public interface IMatchSmiteClient
{
    Task<SmiteClientListResponse<DemoDetailsResponse>?> GetDemoDetailsAsync(
        string sessionId, int matchId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsAsync(
        string sessionId, int matchId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsBatchAsync(
        string sessionId, List<int> matchIds, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<MatchIdsByQueueResponse>?> GetMatchIdsByQueueAsync(
        string sessionId, GameModeQueueIdEnum gameModeQueueId, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<MatchPlayersDetailsResponse>?> GetMatchPlayerDetailsAsync(
        string sessionId, int matchId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<TopMatchesResponse>?> GetTopMatchesAsync(
        string sessionId, CancellationToken cancellationToken = default);
}