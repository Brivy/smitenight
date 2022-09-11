using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IMatchInfoClient
{
    Task<SmiteClientListResponse<DemoDetailsResponse>?> GetDemoDetailsAsync(
        string sessionId, int matchId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsAsync(
        string sessionId, int matchId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsBatchAsync(
        string sessionId, List<int> matchIds, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchIdsByQueueResponse>?> GetMatchIdsByQueueAsync(
        string sessionId, GameModeQueueIdEnum gameModeQueueId, int matchIdDate, int matchIdHour, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchPlayersDetailsResponse>?> GetMatchPlayerDetailsAsync(
        string sessionId, int matchId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<TopMatchesResponse>?> GetTopMatchesAsync(
        string sessionId, CancellationToken cancellationToken);
}