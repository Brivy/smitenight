using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Abstractions.Infrastructure.System;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.GodRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.GodResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.GodResponses;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class GodClient : SmiteClient, IGodSmiteClient
    {
        public GodClient(HttpClient httpClient,
            ISmiteSessionService smiteSessionService,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteSessionService, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<GodsResponse>?> GetGodsAsync(
            GodsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<GodsRequest, GodsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodLeaderbordResponse>?> GetGodLeaderbordAsync(
            GodLeaderboardRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<GodLeaderboardRequest, GodLeaderbordResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodLeaderbordResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodAltAbilitiesResponse>?> GetGodAltAbilitiesAsync(
            GodAltAbilitiesRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<GodAltAbilitiesRequest, GodAltAbilitiesResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodAltAbilitiesResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodSkinsResponse>?> GetGodSkinsAsync(
            GodSkinsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<GodSkinsRequest, GodSkinsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodSkinsResponse>>(result);
        }
    }
}
