using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;

public interface IItemSmiteClientFacade
{
    Task<SmiteClientListResponse<GodRecommendedItemsResponse>?> GetGodRecommendedItemsAsync(int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<ItemsResponse>?> GetItemsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
}