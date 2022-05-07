using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.GodResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.GodResponses;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public class GodSmiteClient : SmiteClient, IGodSmiteClient
    {
        public GodSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper) : base(httpClient, smiteClientSettings, mapper)
        {
        }

        public async Task<SmiteClientListResponse<GodResponse>?> GetGodsAsync(
            GodRequest godRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(godRequest, (int)godRequest.LanguageCode);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<GodResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodLeaderbordResponse>?> GetGodLeaderbordAsync(
            GodLeaderboardRequest godLeaderboardRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(godLeaderboardRequest, godLeaderboardRequest.GodId, (int)godLeaderboardRequest.GameModeQueueId);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<GodLeaderbordResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodLeaderbordResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodAltAbilitiesResponse>?> GetGodAltAbilitiesAsync(
            GodAltAbilitiesRequest godAltAbilitiesRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(godAltAbilitiesRequest);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<GodAltAbilitiesResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodAltAbilitiesResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodSkinsResponse>?> GetGodSkinsAsync(
            GodSkinsRequest godSkinsRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(godSkinsRequest, godSkinsRequest.GodId, (int)godSkinsRequest.LanguageCode);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<GodSkinsResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodSkinsResponse>>(result);
        }
    }
}
