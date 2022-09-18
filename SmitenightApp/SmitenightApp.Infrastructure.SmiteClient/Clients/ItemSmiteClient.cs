using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.ItemClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.ItemResponses;
using SmitenightApp.Infrastructure.SmiteClient.Models;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class ItemSmiteClient : SmiteClient, IItemSmiteClient
    {
        public ItemSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(
            string sessionId, int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(godId, (int) languageCode);
            var request = new SmiteClientRequest(MethodNameConstants.GodRecommendedItemsMethod, sessionId, urlPath);
            var result = await GetListAsync<GodRecommendedItemsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRecommendedItemsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(
            string sessionId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int) languageCode);
            var request = new SmiteClientRequest(MethodNameConstants.ItemsMethod, sessionId, urlPath);
            var result = await GetListAsync<ItemsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<ItemsResponse>>(result);
        }
    }
}
