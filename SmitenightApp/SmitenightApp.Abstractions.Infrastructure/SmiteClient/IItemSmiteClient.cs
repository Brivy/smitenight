using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.ItemResponses;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IItemSmiteClient
{
    Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(
        string sessionId, int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(
        string sessionId, LanguageCodeEnum languageCode, CancellationToken cancellationToken);
}