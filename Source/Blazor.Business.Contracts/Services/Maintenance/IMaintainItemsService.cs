using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance
{
    public interface IMaintainItemsService
    {
        Task<int?> MaintainItemAsync(ItemDto item, string checksum, CancellationToken cancellationToken = default);
        Task<IEnumerable<ItemChecksumsDto>> GetItemChecksumsAsync(CancellationToken cancellationToken = default);
        Task<int> CreateItemAsync(ItemDto item, CancellationToken cancellationToken = default);
        Task LinkItemsAsync(IEnumerable<ItemDto> items, IEnumerable<int> relinkNeededSmiteIds, CancellationToken cancellationToken = default);
        Task LinkActivesAsync(IEnumerable<ItemDto> actives, IEnumerable<int> relinkNeededSmiteIds, CancellationToken cancellationToken = default);
    }
}