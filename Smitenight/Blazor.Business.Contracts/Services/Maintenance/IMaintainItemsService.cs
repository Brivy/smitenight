using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public interface IMaintainItemsService
    {
        Task MaintainItemAsync(ItemDto item, string checksum, CancellationToken cancellationToken = default);
        Task<IEnumerable<ItemChecksumsDto>> GetItemChecksumsAsync(CancellationToken cancellationToken = default);
        Task CreateItemAsync(ItemDto item, CancellationToken cancellationToken = default);
        Task LinkItemsAsync(IEnumerable<ItemDto> items, CancellationToken cancellationToken = default);
        Task LinkActivesAsync(IEnumerable<ItemDto> actives, CancellationToken cancellationToken = default);
    }
}