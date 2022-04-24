using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients;

public partial class SmiteClient
{
    public async Task<IEnumerable<DemoDetailsDto>> GetDemoDetailsAsync(int matchId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.DemoDetailsMethod, urlPath, cancellationToken);
        IEnumerable<DemoDetails> result = await GetAsync<IEnumerable<DemoDetails>>(url, cancellationToken);
        return _mapperService.MapAll<DemoDetails, DemoDetailsDto>(result);
    }

    public async Task<IEnumerable<MatchDetailsDto>> GetMatchDetailsAsync(int matchId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchDetailsMethod, urlPath, cancellationToken);
        IEnumerable<MatchDetails> result = await GetAsync<IEnumerable<MatchDetails>>(url, cancellationToken);
        return _mapperService.MapAll<MatchDetails, MatchDetailsDto>(result);
    }

    public async Task<IEnumerable<MatchDetailsDto>> GetMatchDetailsBatchAsync(List<int> matchIds, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(string.Join(',', matchIds));
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchDetailsBatchMethod, urlPath, cancellationToken);
        IEnumerable<MatchDetails> result = await GetAsync<IEnumerable<MatchDetails>>(url, cancellationToken);
        return _mapperService.MapAll<MatchDetails, MatchDetailsDto>(result);
    }

    public async Task<IEnumerable<MatchIdsByQueueDto>> GetMatchIdsByQueueAsync(GameModeQueue gameModeQueue, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath((int)gameModeQueue, matchIdDate, matchIdHour);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchIdsByQueueMethod, urlPath, cancellationToken);
        IEnumerable<MatchIdsByQueue> result = await GetAsync<IEnumerable<MatchIdsByQueue>>(url, cancellationToken);
        return _mapperService.MapAll<MatchIdsByQueue, MatchIdsByQueueDto>(result);
    }

    public async Task<IEnumerable<MatchPlayerDetailsDto>> GetMatchPlayerDetailsAsync(int matchId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchPlayerDetailsMethod, urlPath, cancellationToken);
        IEnumerable<MatchPlayerDetails> result = await GetAsync<IEnumerable<MatchPlayerDetails>>(url, cancellationToken);
        return _mapperService.MapAll<MatchPlayerDetails, MatchPlayerDetailsDto>(result);
    }

    public async Task<IEnumerable<TopMatchDto>> GetTopMatchesAsync(CancellationToken cancellationToken = default)
    {
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TopMatchesMethod, cancellationToken);
        IEnumerable<TopMatch> result = await GetAsync<IEnumerable<TopMatch>>(url, cancellationToken);
        return _mapperService.MapAll<TopMatch, TopMatchDto>(result);
    }
}
