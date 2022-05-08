using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.ItemRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.ItemResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.ItemResponses;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public class ItemSmiteClient : SmiteClient, IItemSmiteClient
    {
        public ItemSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper) : base(httpClient, smiteClientSettings, mapper)
        {
        }

        public async Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(
            GodRecommendedItemsRequest godRecommendedItemsRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(godRecommendedItemsRequest, godRecommendedItemsRequest.GodId, (int)godRecommendedItemsRequest.LanguageCode);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<GodRecommendedItemsResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRecommendedItemsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(
            ItemsRequest itemsRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(itemsRequest, (int)itemsRequest.LanguageCode);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<ItemsResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<ItemsResponse>>(result);
        }
    }
}
