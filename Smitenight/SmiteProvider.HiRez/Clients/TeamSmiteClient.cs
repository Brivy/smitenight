using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Clients.TeamClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.TeamResponses;
using Smitenight.Providers.SmiteProvider.HiRez.Models;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class TeamSmiteClient : SmiteClient, ITeamSmiteClient
    {
        public TeamSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(
            string sessionId, int clanId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(clanId);
            var request = new SmiteClientRequest(MethodNameConstants.TeamDetailsMethod, sessionId, urlPath);
            var result = await GetListAsync<TeamDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<TeamDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(
            string sessionId, int clanId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(clanId);
            var request = new SmiteClientRequest(MethodNameConstants.TeamPlayersMethod, sessionId, urlPath);
            var result = await GetListAsync<TeamPlayersResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<TeamPlayersResponse>>(result);
        }

        public async Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(
            string sessionId, string teamName, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(teamName);
            var request = new SmiteClientRequest(MethodNameConstants.SearchTeamsMethod, sessionId, urlPath);
            var result = await GetListAsync<SearchTeamsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<SearchTeamsResponse>>(result);
        }
    }
}
