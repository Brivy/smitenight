using SmitenightApp.Abstractions.Application.Facades.SmiteClient;
using SmitenightApp.Abstractions.Application.Services.Cache;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.ItemClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Application.Facades.SmiteClient
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
