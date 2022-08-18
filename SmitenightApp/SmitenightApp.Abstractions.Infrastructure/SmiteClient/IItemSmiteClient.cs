using SmitenightApp.Domain.Clients.SmiteClient.Requests.ItemRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.ItemResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IItemSmiteClient
{
    Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(
        GodRecommendedItemsRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(
        ItemsRequest request, CancellationToken cancellationToken);
}