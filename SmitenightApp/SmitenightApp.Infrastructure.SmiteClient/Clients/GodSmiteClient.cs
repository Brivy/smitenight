using AutoMapper;
using Microsoft.Extensions.Options;
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
    public class GodSmiteClient : SmiteClient, IGodSmiteClient
    {
        public GodSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<GodsResponse>?> GetGodsAsync(
            string sessionId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int) languageCode);
            var request = new SmiteClientRequest(MethodNameConstants.GodsMethod, sessionId, urlPath);
            var result = await GetListAsync<GodsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodLeaderbordResponse>?> GetGodLeaderbordAsync(
            string sessionId, int godId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(godId, (int) gameModeQueueId);
            var request = new SmiteClientRequest(MethodNameConstants.GodLeaderboardMethod, sessionId, urlPath);
            var result = await GetListAsync<GodLeaderbordResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodLeaderbordResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodAltAbilitiesResponse>?> GetGodAltAbilitiesAsync(
            string sessionId, CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.GodAltAbilitiesMethod, sessionId);
            var result = await GetListAsync<GodAltAbilitiesResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodAltAbilitiesResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodSkinsResponse>?> GetGodSkinsAsync(
            string sessionId, int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(godId, (int) languageCode);
            var request = new SmiteClientRequest(MethodNameConstants.GodSkinsMethod, sessionId, urlPath);
            var result = await GetListAsync<GodSkinsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodSkinsResponse>>(result);
        }
    }
}
