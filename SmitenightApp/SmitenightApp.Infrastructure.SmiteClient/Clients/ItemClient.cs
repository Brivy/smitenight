using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.ItemRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.ItemResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.ItemResponses;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class ItemClient : SmiteClient, IItemSmiteClient
    {
        public ItemClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(
            GodRecommendedItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<GodRecommendedItemsRequest, GodRecommendedItemsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRecommendedItemsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(
            ItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<ItemsRequest, ItemsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<ItemsResponse>>(result);
        }
    }
}
