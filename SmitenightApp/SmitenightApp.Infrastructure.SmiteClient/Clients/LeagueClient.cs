using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Abstractions.Infrastructure.System;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.LeagueRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.LeagueResponses;
using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.LeagueResponses;
using SmitenightApp.Infrastructure.SmiteClient.Models;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class LeagueClient : SmiteClient, ILeagueClient
    {
        public LeagueClient(HttpClient httpClient,
            ISmiteSessionService smiteSessionService,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteSessionService, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(
            string sessionId, GameModeQueueIdEnum gameModeQueueId, LeagueTierEnum leagueTier, int round, CancellationToken cancellationToken)
        {
            var urlPath = ConstructUrlPath((int) gameModeQueueId, (int) leagueTier);
            var request = new SmiteClientRequest(MethodNameConstants.LeagueLeaderbordMethod, sessionId, urlPath);
            var result = await GetListAsync<LeagueLeaderboardResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<LeagueLeaderboardResponse>>(result);
        }

        public async Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(
            string sessionId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken)
        {
            var urlPath = ConstructUrlPath((int) gameModeQueueId);
            var request = new SmiteClientRequest(MethodNameConstants.LeagueSeasonsMethod, sessionId, urlPath);
            var result = await GetListAsync<LeagueSeasonsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<LeagueSeasonsResponse>>(result);
        }
    }
}
