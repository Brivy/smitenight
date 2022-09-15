using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Application.System;
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
    public class ItemClient : SmiteClient, IItemSmiteClient
    {
        public ItemClient(HttpClient httpClient,
            ISmiteSessionService smiteSessionService,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteSessionService, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(int godId, LanguageCodeEnum languageCode, 
            CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(godId, (int) languageCode);
            var request = new SmiteClientRequest(MethodNameConstants.GodRecommendedItemsMethod, urlPath);
            var result = await GetListAsync<GodRecommendedItemsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRecommendedItemsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(LanguageCodeEnum languageCode, 
            CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int) languageCode);
            var request = new SmiteClientRequest(MethodNameConstants.ItemsMethod, urlPath);
            var result = await GetListAsync<ItemsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<ItemsResponse>>(result);
        }
    }
}
