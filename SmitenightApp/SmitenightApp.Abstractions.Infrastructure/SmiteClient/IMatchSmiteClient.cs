using SmitenightApp.Domain.Clients.MatchClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

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