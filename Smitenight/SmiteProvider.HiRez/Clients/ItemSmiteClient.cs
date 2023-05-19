using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class ItemSmiteClient : SmiteClient, IItemSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapperService _mapperService;

        public ItemSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapperService mapperService) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapperService = mapperService;
        }

        public async Task<IEnumerable<GodRecommendedItemDto>> GetGodRecommendedItemsAsync(int godId, LanguageCode languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(godId, (int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodRecommendedItemsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodRecommendedItem>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<GodRecommendedItem>, IEnumerable<GodRecommendedItemDto>>(result);
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAsync(LanguageCode languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.ItemsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<Item>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<Item>, IEnumerable<ItemDto>>(result);
        }
    }
}
