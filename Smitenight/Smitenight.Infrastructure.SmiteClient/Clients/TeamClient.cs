using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.TeamRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.TeamResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.TeamResponses;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public class TeamClient : SmiteClient, ITeamClient
    {
        public TeamClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper) : base(httpClient, smiteClientSettings, mapper)
        {
        }

        public async Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(
            TeamDetailsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<TeamDetailsResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<TeamDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(
            TeamPlayersRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<TeamPlayersResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<TeamPlayersResponse>>(result);
        }

        public async Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(
            SearchTeamsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<SearchTeamsResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<SearchTeamsResponse>>(result);
        }
    }
}
