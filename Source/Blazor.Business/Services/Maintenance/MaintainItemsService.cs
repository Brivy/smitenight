using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public class MaintainItemsService : IMaintainItemsService
    {
        private readonly IMaintainItemsRepository _maintainItemsRepository;
        private readonly IChecksumService _checksumService;
        private readonly IMapperService _mapperService;

        public MaintainItemsService(
            IMaintainItemsRepository maintainItemsRepository,
            IChecksumService checksumService,
            IMapperService mapperService)
        {
            _maintainItemsRepository = maintainItemsRepository;
            _checksumService = checksumService;
            _mapperService = mapperService;
        }

        public async Task<int?> MaintainItemAsync(ItemDto item, string checksum, CancellationToken cancellationToken = default)
        {
            if (!_checksumService.IsChecksumDifferent(checksum, item))
            {
                return null;
            }

            return await CreateItemAsync(item, cancellationToken);
        }

        public Task<int> CreateItemAsync(ItemDto item, CancellationToken cancellationToken = default)
        {
            switch (item.Type)
            {
                case ItemConstants.ItemType:
                    var createdItem = _mapperService.Map<ItemDto, CreateItemDto>(item);
                    return _maintainItemsRepository.CreateItemAsync(createdItem, cancellationToken);
                case ItemConstants.ConsumableItemType:
                    var createdActive = _mapperService.Map<ItemDto, CreateActiveDto>(item);
                    return _maintainItemsRepository.CreateActiveAsync(createdActive, cancellationToken);
                case ItemConstants.ActiveItemType:
                    var createdConsumable = _mapperService.Map<ItemDto, CreateConsumableDto>(item);
                    return _maintainItemsRepository.CreateConsumableAsync(createdConsumable, cancellationToken);
                default:
                    throw new NotImplementedException($"Specified {item.Type} can not be processed");
            }
        }

        public async Task LinkItemsAsync(IEnumerable<ItemDto> items, IEnumerable<int> relinkNeededSmiteIds, CancellationToken cancellationToken = default)
        {
            var updatedLinkItems = new List<UpdateItemLinkDto>();
            var linkItems = await _maintainItemsRepository.GetItemForRelinkingAsync(relinkNeededSmiteIds, cancellationToken);
            foreach (var linkItem in linkItems)
            {
                var item = items.Single(x => x.ItemId == linkItem.SmiteId);
                var childItemId = linkItems.SingleOrDefault(x => x.SmiteId == item.ChildItemId)?.NewItemId;
                var rootItemId = linkItems.SingleOrDefault(x => x.SmiteId == item.RootItemId)?.NewItemId;

                if (linkItem.OldItemId.HasValue)
                {
                    childItemId = linkItems.SingleOrDefault(x => x.RootItemId == linkItem.OldItemId)?.NewItemId ?? linkItem.ChildItemId;
                    rootItemId = linkItems.SingleOrDefault(x => x.ChildItemId == linkItem.OldItemId)?.NewItemId ?? linkItem.RootItemId;
                }

                updatedLinkItems.Add(new UpdateItemLinkDto
                {
                    Id = linkItem.NewItemId,
                    ChildItemId = childItemId,
                    RootItemId = rootItemId
                });
            }

            await _maintainItemsRepository.UpdateItemLinksAsync(updatedLinkItems, cancellationToken);
        }

        public async Task LinkActivesAsync(IEnumerable<ItemDto> actives, IEnumerable<int> relinkNeededSmiteIds, CancellationToken cancellationToken = default)
        {
            var updatedLinkActives = new List<UpdateActiveLinkDto>();
            var linkActives = await _maintainItemsRepository.GetActivesForRelinkingAsync(relinkNeededSmiteIds, cancellationToken);
            foreach (var linkActive in linkActives)
            {
                var item = actives.Single(x => x.ItemId == linkActive.SmiteId);
                var childActiveId = linkActives.SingleOrDefault(x => x.SmiteId == item.ChildItemId)?.NewItemId;
                var rootActiveId = linkActives.SingleOrDefault(x => x.SmiteId == item.RootItemId)?.NewItemId;

                if (linkActive.OldItemId.HasValue)
                {
                    childActiveId = linkActives.SingleOrDefault(x => x.RootActiveId == linkActive.OldItemId)?.NewItemId ?? linkActive.ChildActiveId;
                    rootActiveId = linkActives.SingleOrDefault(x => x.ChildActiveId == linkActive.OldItemId)?.NewItemId ?? linkActive.RootActiveId;
                }

                updatedLinkActives.Add(new UpdateActiveLinkDto
                {
                    Id = linkActive.NewItemId,
                    ChildActiveId = childActiveId,
                    RootActiveId = rootActiveId
                });
            }

            await _maintainItemsRepository.UpdateActiveLinksAsync(updatedLinkActives, cancellationToken);
        }

        public Task<IEnumerable<ItemChecksumsDto>> GetItemChecksumsAsync(CancellationToken cancellationToken = default)
        {
            return _maintainItemsRepository.GetItemChecksumsDto(cancellationToken);
        }
    }
}
