using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IItemSmiteClient
{
    Task<IEnumerable<GodRecommendedItemDto>> GetGodRecommendedItemsAsync(int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);

    Task<IEnumerable<ItemDto>> GetItemsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
}