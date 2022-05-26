using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.LeagueRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.LeagueResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.LeagueResponses;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public class LeagueClient : SmiteClient, ILeagueClient
    {
        public LeagueClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper) : base(httpClient, smiteClientSettings, mapper)
        {
        }

        public async Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(
            LeagueLeaderboardRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<LeagueLeaderboardResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<LeagueLeaderboardResponse>>(result);
        }

        public async Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(
            LeagueSeasonsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<LeagueSeasonsResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<LeagueSeasonsResponse>>(result);
        }
    }
}
