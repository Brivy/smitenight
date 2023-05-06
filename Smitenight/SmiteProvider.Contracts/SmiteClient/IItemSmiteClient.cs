using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

public interface IItemSmiteClient
{
    Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(
        string sessionId, int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(
        string sessionId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
}