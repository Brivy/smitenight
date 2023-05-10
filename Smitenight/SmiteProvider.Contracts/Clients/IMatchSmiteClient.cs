using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IMatchSmiteClient
{
    Task<IEnumerable<DemoDetails>> GetDemoDetailsAsync(int matchId, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchDetails>> GetMatchDetailsAsync(int matchId, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchDetails>> GetMatchDetailsBatchAsync(List<int> matchIds, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchIdsByQueue>> GetMatchIdsByQueueAsync(GameModeQueueIdEnum gameModeQueueId, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default);

    Task<IEnumerable<MatchPlayersDetails>> GetMatchPlayerDetailsAsync(int matchId, CancellationToken cancellationToken = default);

    Task<IEnumerable<TopMatch>> GetTopMatchesAsync(CancellationToken cancellationToken = default);
}