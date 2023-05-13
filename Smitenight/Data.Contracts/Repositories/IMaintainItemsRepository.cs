using Smitenight.Persistence.Data.Contracts.Models;

namespace Smitenight.Persistence.Data.Contracts.Repositories
{
    public interface IMaintainItemsRepository
    {
        Task<IEnumerable<ItemLinkDto>> GetItemLinksAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ActiveLinkDto>> GetActiveLinksAsync(CancellationToken cancellationToken = default);
        Task CreateItemAsync(CreateItemDto item, IEnumerable<CreateItemDescriptionDto> itemDescriptions, CancellationToken cancellationToken = default);
        Task CreateActiveAsync(CreateActiveDto active, CancellationToken cancellationToken = default);
        Task CreateConsumableAsync(CreateConsumableDto consumable, CancellationToken cancellationToken = default);
        Task UpdateItemLinksAsync(IEnumerable<UpdateItemLinkDto> itemLinks, CancellationToken cancellationToken = default);
        Task UpdateActiveLinksAsync(IEnumerable<UpdateActiveLinkDto> itemLinks, CancellationToken cancellationToken = default);
    }
}
