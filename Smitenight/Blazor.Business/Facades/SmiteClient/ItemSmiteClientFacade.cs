using Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;
using Smitenight.Application.Blazor.Business.Contracts.Services.Cache;
using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

namespace Smitenight.Application.Blazor.Business.Facades.SmiteClient
{
    /// <summary>
    /// Simplified version without sessionId of <see cref="IItemSmiteClient"/>
    /// </summary>
    public class ItemSmiteClientFacade : IItemSmiteClientFacade
    {
        private readonly IItemSmiteClient _itemSmiteClient;
        private readonly ISmiteSessionCacheService _smiteSessionCacheService;

        public ItemSmiteClientFacade(
            IItemSmiteClient itemSmiteClient,
            ISmiteSessionCacheService smiteSessionCacheService)
        {
            _itemSmiteClient = itemSmiteClient;
            _smiteSessionCacheService = smiteSessionCacheService;
        }

        public async Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default) =>
            await _itemSmiteClient.GetGodRecommendedItemsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), godId, languageCode, cancellationToken);

        public async Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default) =>
            await _itemSmiteClient.GetItemsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), languageCode, cancellationToken);
    }
}
