using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public interface IMaintainItemsService
    {
        Task CreateActiveAsync(ItemDto active, CancellationToken cancellationToken = default);
        Task CreateConsumableAsync(ItemDto consumable, CancellationToken cancellationToken = default);
        Task CreateItemAsync(ItemDto item, CancellationToken cancellationToken = default);
        Task LinkItemsAsync(IEnumerable<ItemDto> items, CancellationToken cancellationToken = default);
        Task LinkActivesAsync(IEnumerable<ItemDto> actives, CancellationToken cancellationToken = default);
    }
}