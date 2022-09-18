using SmitenightApp.Domain.Clients.ItemClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Application.Facades.SmiteClient;

public interface IItemSmiteClientFacade
{
    Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
}