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
    public class ItemClient : SmiteClient, IItemSmiteClient
    {
        public ItemClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper) : base(httpClient, smiteClientSettings, mapper)
        {
        }

        public async Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(
            GodRecommendedItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<GodRecommendedItemsRequest, GodRecommendedItemsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRecommendedItemsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<ItemResponse>?> GetItemsAsync(
            ItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<ItemsRequest, ItemResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<ItemResponse>>(result);
        }
    }
}
