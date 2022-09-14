using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Application.System;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
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

        public async Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(GameModeQueueIdEnum gameModeQueueId, 
            LeagueTierEnum leagueTier, int round, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int) gameModeQueueId, (int) leagueTier);
            var request = new SmiteClientRequest(MethodNameConstants.LeagueLeaderbordMethod, urlPath);
            var result = await GetListAsync<LeagueLeaderboardResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<LeagueLeaderboardResponse>>(result);
        }

        public async Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(GameModeQueueIdEnum gameModeQueueId, 
            CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int) gameModeQueueId);
            var request = new SmiteClientRequest(MethodNameConstants.LeagueSeasonsMethod, urlPath);
            var result = await GetListAsync<LeagueSeasonsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<LeagueSeasonsResponse>>(result);
        }
    }
}
