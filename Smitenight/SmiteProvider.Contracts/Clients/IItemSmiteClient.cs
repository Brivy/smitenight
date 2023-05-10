using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IItemSmiteClient
{
    Task<IEnumerable<GodRecommendedItem>> GetGodRecommendedItemsAsync(int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);

    Task<IEnumerable<Item>> GetItemsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
}