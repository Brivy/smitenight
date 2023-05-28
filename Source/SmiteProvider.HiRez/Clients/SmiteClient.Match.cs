using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public partial class SmiteClient
    {
        public async Task<IEnumerable<DemoDetailsDto>> GetDemoDetailsAsync(int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.DemoDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<DemoDetails>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<DemoDetails>, IEnumerable<DemoDetailsDto>>(result);
        }

        public async Task<IEnumerable<MatchDetailsDto>> GetMatchDetailsAsync(int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchDetails>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<MatchDetails>, IEnumerable<MatchDetailsDto>>(result);
        }

        public async Task<IEnumerable<MatchDetailsDto>> GetMatchDetailsBatchAsync(List<int> matchIds, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(string.Join(',', matchIds));
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchDetailsBatchMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchDetails>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<MatchDetails>, IEnumerable<MatchDetailsDto>>(result);
        }

        public async Task<IEnumerable<MatchIdsByQueueDto>> GetMatchIdsByQueueAsync(GameModeQueue gameModeQueue, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)gameModeQueue, matchIdDate, matchIdHour);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchIdsByQueueMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchIdsByQueue>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<MatchIdsByQueue>, IEnumerable<MatchIdsByQueueDto>>(result);
        }

        public async Task<IEnumerable<MatchPlayerDetailsDto>> GetMatchPlayerDetailsAsync(int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(matchId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchPlayerDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<MatchPlayerDetails>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<MatchPlayerDetails>, IEnumerable<MatchPlayerDetailsDto>>(result);
        }

        public async Task<IEnumerable<TopMatchDto>> GetTopMatchesAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TopMatchesMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<TopMatch>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<TopMatch>, IEnumerable<TopMatchDto>>(result);
        }
    }
}
