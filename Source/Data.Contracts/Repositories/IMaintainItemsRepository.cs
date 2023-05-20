using Smitenight.Persistence.Data.Contracts.Models;

namespace Smitenight.Persistence.Data.Contracts.Repositories
{
    public interface IMaintainItemsRepository
    {
        Task<IEnumerable<ItemChecksumsDto>> GetItemChecksumsDto(CancellationToken cancellationToken = default);
        Task<IEnumerable<ItemLinkDto>> GetItemForRelinkingAsync(IEnumerable<int> relinkNeededItemIds, CancellationToken cancellationToken = default);
        Task<IEnumerable<ActiveLinkDto>> GetActivesForRelinkingAsync(CancellationToken cancellationToken = default);
        Task<int> CreateItemAsync(CreateItemDto item, IEnumerable<CreateItemDescriptionDto> itemDescriptions, CancellationToken cancellationToken = default);
        Task<int> CreateActiveAsync(CreateActiveDto active, CancellationToken cancellationToken = default);
        Task<int> CreateConsumableAsync(CreateConsumableDto consumable, CancellationToken cancellationToken = default);
        Task UpdateItemLinksAsync(IEnumerable<UpdateItemLinkDto> itemLinks, CancellationToken cancellationToken = default);
        Task UpdateActiveLinksAsync(IEnumerable<UpdateActiveLinkDto> itemLinks, CancellationToken cancellationToken = default);
    }
}
