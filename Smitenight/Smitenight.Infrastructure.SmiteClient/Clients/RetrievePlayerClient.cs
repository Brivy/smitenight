using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.RetrievePlayerResponses;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public class RetrievePlayerClient : SmiteClient, IRetrievePlayerClient
    {
        public RetrievePlayerClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper) : base(httpClient, smiteClientSettings, mapper)
        {
        }

        public async Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerAsync(
            PlayerRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<PlayerRequest, PlayerResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(
            PlayerWithoutPortalRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<PlayerWithoutPortalRequest, PlayerResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(
            PlayerIdByNameRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<PlayerIdByNameRequest, PlayerIdResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerIdResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(
            PlayerIdByPortalUserRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<PlayerIdByPortalUserRequest, PlayerIdResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerIdResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(
            PlayerIdByGamerTagRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<PlayerIdByGamerTagRequest, PlayerIdResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerIdResponse>>(result);
        }
    }
}
