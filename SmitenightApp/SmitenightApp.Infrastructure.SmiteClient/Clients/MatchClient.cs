using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Application.System;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.MatchClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.MatchResponses;
using SmitenightApp.Infrastructure.SmiteClient.Models;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class MatchClient : SmiteClient, IMatchInfoClient
    {
        public MatchClient(HttpClient httpClient,
            ISmiteSessionService smiteSessionService,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteSessionService, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<DemoDetailsResponse>?> GetDemoDetailsAsync(int matchId, 
            CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(matchId);
            var request = new SmiteClientRequest(MethodNameConstants.DemoDetailsMethod, urlPath);
            var result = await GetListAsync<DemoDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<DemoDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsAsync(int matchId, 
            CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(matchId);
            var request = new SmiteClientRequest(MethodNameConstants.MatchDetailsMethod, urlPath);
            var result = await GetListAsync<MatchDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsBatchAsync(List<int> matchIds, 
            CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(string.Join(',', matchIds));
            var request = new SmiteClientRequest(MethodNameConstants.MatchDetailsBatchMethod, urlPath);
            var result = await GetListAsync<MatchDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchIdsByQueueResponse>?> GetMatchIdsByQueueAsync(GameModeQueueIdEnum gameModeQueueId, 
            int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int) gameModeQueueId, matchIdDate, matchIdHour);
            var request = new SmiteClientRequest(MethodNameConstants.MatchIdsByQueueMethod, urlPath);
            var result = await GetListAsync<MatchIdsByQueueResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchIdsByQueueResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchPlayersDetailsResponse>?> GetMatchPlayerDetailsAsync(int matchId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(matchId);
            var request = new SmiteClientRequest(MethodNameConstants.MatchPlayerDetailsMethod, urlPath);
            var result = await GetListAsync<MatchPlayersDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchPlayersDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<TopMatchesResponse>?> GetTopMatchesAsync(CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.TopMatchesMethod);
            var result = await GetListAsync<TopMatchesResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<TopMatchesResponse>>(result);
        }
    }
}
