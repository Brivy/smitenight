using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;

public interface IMatchSmiteClientFacade
{
    Task<SmiteClientListResponse<DemoDetailsResponse>?> GetDemoDetailsAsync(int matchId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsAsync(int matchId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsBatchAsync(List<int> matchIds, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<MatchIdsByQueueResponse>?> GetMatchIdsByQueueAsync(GameModeQueueIdEnum gameModeQueueId, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<MatchPlayersDetailsResponse>?> GetMatchPlayerDetailsAsync(int matchId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<TopMatchesResponse>?> GetTopMatchesAsync(CancellationToken cancellationToken = default);
}