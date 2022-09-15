using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Application.System;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.GodClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.GodResponses;
using SmitenightApp.Infrastructure.SmiteClient.Models;
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

        public async Task<SmiteClientListResponse<GodsResponse>?> GetGodsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int) languageCode);
            var request = new SmiteClientRequest(MethodNameConstants.GodsMethod, urlPath);
            var result = await GetListAsync<GodsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodLeaderbordResponse>?> GetGodLeaderbordAsync(int godId, GameModeQueueIdEnum gameModeQueueId, 
            CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(godId, (int) gameModeQueueId);
            var request = new SmiteClientRequest(MethodNameConstants.GodLeaderboardMethod, urlPath);
            var result = await GetListAsync<GodLeaderbordResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodLeaderbordResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodAltAbilitiesResponse>?> GetGodAltAbilitiesAsync(CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.GodAltAbilitiesMethod);
            var result = await GetListAsync<GodAltAbilitiesResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodAltAbilitiesResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodSkinsResponse>?> GetGodSkinsAsync(int godId, LanguageCodeEnum languageCode, 
            CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(godId, (int) languageCode);
            var request = new SmiteClientRequest(MethodNameConstants.GodSkinsMethod, urlPath);
            var result = await GetListAsync<GodSkinsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodSkinsResponse>>(result);
        }
    }
}
