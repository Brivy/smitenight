using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.LeagueRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.LeagueResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.LeagueResponses;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class LeagueClient : SmiteClient, ILeagueClient
    {
        public LeagueClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(
            LeagueLeaderboardRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<LeagueLeaderboardRequest, LeagueLeaderboardResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<LeagueLeaderboardResponse>>(result);
        }

        public async Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(
            LeagueSeasonsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<LeagueSeasonsRequest, LeagueSeasonsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<LeagueSeasonsResponse>>(result);
        }
    }
}
