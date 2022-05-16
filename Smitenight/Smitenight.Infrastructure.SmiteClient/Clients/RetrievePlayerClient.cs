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
            PlayerRequest playerRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(playerRequest, playerRequest.PlayerId, (int)playerRequest.PortalType);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<PlayerResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(
            PlayerWithoutPortalRequest playerWithoutPortalRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(playerWithoutPortalRequest, playerWithoutPortalRequest.PlayerName);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<PlayerResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(
            PlayerIdByPlayerNameRequest playerIdByPlayerNameRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(playerIdByPlayerNameRequest, playerIdByPlayerNameRequest.PlayerName);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<PlayerIdResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerIdResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(
            PlayerIdByPortalUserRequest playerIdByPortalUserRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(playerIdByPortalUserRequest, (int)playerIdByPortalUserRequest.PortalType, playerIdByPortalUserRequest.PortalUserId);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<PlayerIdResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerIdResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(
            PlayerIdByGamerTagRequest playerIdByGamerTagRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(playerIdByGamerTagRequest, (int)playerIdByGamerTagRequest.PortalType, playerIdByGamerTagRequest.GamerTag);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<PlayerIdResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerIdResponse>>(result);
        }
    }
}
