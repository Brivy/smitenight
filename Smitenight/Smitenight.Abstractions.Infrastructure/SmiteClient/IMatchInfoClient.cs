using Smitenight.Domain.Clients.SmiteClient.Requests.MatchInfoRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.MatchInfoResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface IMatchInfoClient
{
    Task<SmiteClientListResponse<DemoDetailsResponse>?> GetDemoDetailsAsync(
        DemoDetailsRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsAsync(
        MatchDetailsRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsBatchAsync(
        MatchDetailsBatchRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchIdsByQueueResponse>?> GetMatchIdsByQueueAsync(
        MatchIdsByQueueRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MatchPlayersDetailsResponse>?> GetMatchPlayerDetailsAsync(
        MatchPlayersDetailsRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<TopMatchesResponse>?> GetTopMatchesAsync(
        TopMatchesRequest request, CancellationToken cancellationToken);
}