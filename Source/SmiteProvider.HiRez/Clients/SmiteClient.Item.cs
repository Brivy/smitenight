using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.ItemClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public partial class SmiteClient
    {
        public async Task<IEnumerable<GodRecommendedItemDto>> GetGodRecommendedItemsAsync(int godId, LanguageCode languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(godId, (int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodRecommendedItemsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodRecommendedItem>>(url, cancellationToken);
            return _mapperService.MapAll<GodRecommendedItem, GodRecommendedItemDto>(result);
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAsync(LanguageCode languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.ItemsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<Item>>(url, cancellationToken);
            return _mapperService.MapAll<Item, ItemDto>(result);
        }
    }
}
