using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IMatchSmiteClient
{
    Task<IEnumerable<DemoDetailsDto>> GetDemoDetailsAsync(int matchId, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchDetailsDto>> GetMatchDetailsAsync(int matchId, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchDetailsDto>> GetMatchDetailsBatchAsync(List<int> matchIds, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchIdsByQueueDto>> GetMatchIdsByQueueAsync(GameModeQueueIdEnum gameModeQueueId, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchPlayersDetailsDto>> GetMatchPlayerDetailsAsync(int matchId, CancellationToken cancellationToken = default);

    Task<IEnumerable<TopMatchDto>> GetTopMatchesAsync(CancellationToken cancellationToken = default);
}