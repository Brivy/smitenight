using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.ItemResponses;
using Smitenight.Providers.SmiteProvider.HiRez.Models;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
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
            var urlPath = ConstructUrlPath(godId, (int)languageCode);
            var request = new SmiteClientRequest(MethodNameConstants.GodRecommendedItemsMethod, sessionId, urlPath);
            var result = await GetListAsync<GodRecommendedItemsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRecommendedItemsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(
            string sessionId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int)languageCode);
            var request = new SmiteClientRequest(MethodNameConstants.ItemsMethod, sessionId, urlPath);
            var result = await GetListAsync<ItemsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<ItemsResponse>>(result);
        }
    }
}
