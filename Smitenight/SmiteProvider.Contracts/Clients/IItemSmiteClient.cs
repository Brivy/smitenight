using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IItemSmiteClient
{
    Task<IEnumerable<GodRecommendedItemDto>> GetGodRecommendedItemsAsync(int godId, LanguageCode languageCode, CancellationToken cancellationToken = default);

    Task<IEnumerable<ItemDto>> GetItemsAsync(LanguageCode languageCode, CancellationToken cancellationToken = default);
}