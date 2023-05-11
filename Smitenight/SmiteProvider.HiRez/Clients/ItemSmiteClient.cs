using AutoMapper;
using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Models.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class ItemSmiteClient : SmiteClient, IItemSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapper _mapper;

        public ItemSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapper mapper) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GodRecommendedItemDto>> GetGodRecommendedItemsAsync(int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(godId, (int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodRecommendedItemsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodRecommendedItem>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<GodRecommendedItemDto>>(result);
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.ItemsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<Item>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<ItemDto>>(result);
        }
    }
}
