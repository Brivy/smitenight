using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.MatchResponses;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public class MatchClient : SmiteClient, IMatchInfoClient
    {
        public MatchClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper) : base(httpClient, smiteClientSettings, mapper)
        {
        }

        public async Task<SmiteClientListResponse<DemoDetailsResponse>?> GetDemoDetailsAsync(
            DemoDetailsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<DemoDetailsRequest, DemoDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<DemoDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsAsync(
            MatchDetailsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<MatchDetailsRequest, MatchDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchDetailsResponse>?> GetMatchDetailsBatchAsync(
            MatchDetailsBatchRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<MatchDetailsBatchRequest, MatchDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchIdsByQueueResponse>?> GetMatchIdsByQueueAsync(
            MatchIdsByQueueRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<MatchIdsByQueueRequest, MatchIdsByQueueResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchIdsByQueueResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchPlayersDetailsResponse>?> GetMatchPlayerDetailsAsync(
            MatchPlayersDetailsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<MatchPlayersDetailsRequest, MatchPlayersDetailsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchPlayersDetailsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<TopMatchesResponse>?> GetTopMatchesAsync(
            TopMatchesRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<TopMatchesRequest, TopMatchesResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<TopMatchesResponse>>(result);
        }
    }
}
