using Smitenight.Domain.Clients.SmiteClient.Requests.ItemRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.ItemResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface IItemSmiteClient
{
    Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(
        GodRecommendedItemsRequest godRecommendedItemsRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(
        ItemsRequest itemsRequest, CancellationToken cancellationToken);
}