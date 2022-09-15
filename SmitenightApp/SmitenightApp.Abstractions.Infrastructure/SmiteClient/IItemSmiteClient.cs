using SmitenightApp.Domain.Clients.ItemClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IItemSmiteClient
{
    Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(
        int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(
        LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
}