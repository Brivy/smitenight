using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.MatchResponses;
using Smitenight.Providers.SmiteProvider.HiRez.Models;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class MatchSmiteClient : SmiteClient, IMatchSmiteClient
    {
        public MatchSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<DemoDetailsResponse>?> GetDemoDetailsAsync(
            string sessionId, int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(matchId);
            var request = new SmiteClientRequest(MethodNameConstants.DemoDetailsMethod, sessionId, urlPath);
            var result = await GetListAsync<DemoDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<DemoDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsAsync(
            string sessionId, int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(matchId);
            var request = new SmiteClientRequest(MethodNameConstants.MatchDetailsMethod, sessionId, urlPath);
            var result = await GetListAsync<MatchDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsBatchAsync(
            string sessionId, List<int> matchIds, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(string.Join(',', matchIds));
            var request = new SmiteClientRequest(MethodNameConstants.MatchDetailsBatchMethod, sessionId, urlPath);
            var result = await GetListAsync<MatchDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchIdsByQueueResponse>?> GetMatchIdsByQueueAsync(
            string sessionId, GameModeQueueIdEnum gameModeQueueId, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int)gameModeQueueId, matchIdDate, matchIdHour);
            var request = new SmiteClientRequest(MethodNameConstants.MatchIdsByQueueMethod, sessionId, urlPath);
            var result = await GetListAsync<MatchIdsByQueueResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchIdsByQueueResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchPlayersDetailsResponse>?> GetMatchPlayerDetailsAsync(
            string sessionId, int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(matchId);
            var request = new SmiteClientRequest(MethodNameConstants.MatchPlayerDetailsMethod, sessionId, urlPath);
            var result = await GetListAsync<MatchPlayersDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchPlayersDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<TopMatchesResponse>?> GetTopMatchesAsync(
            string sessionId, CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.TopMatchesMethod, sessionId);
            var result = await GetListAsync<TopMatchesResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<TopMatchesResponse>>(result);
        }
    }
}
