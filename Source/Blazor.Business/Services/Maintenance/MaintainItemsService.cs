using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
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
                    var createdItemDescriptions = CreateItemDescriptions(item.ItemDescription.ItemSubDescriptions);
                    return _maintainItemsRepository.CreateItemAsync(createdItem, createdItemDescriptions, cancellationToken);
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

        public async Task LinkItemsAsync(IEnumerable<ItemDto> items, IEnumerable<int> relinkNeededItemIds, CancellationToken cancellationToken = default)
        {
            var updatedLinkItems = new List<UpdateItemLinkDto>();
            var linkItems = await _maintainItemsRepository.GetItemForRelinkingAsync(cancellationToken);

            foreach (var linkItem in linkItems)
            {
                var item = items.Single(x => x.ItemId == linkItem.SmiteId);
                var childItem = linkItems.SingleOrDefault(x => x.SmiteId == item.ChildItemId);
                var rootItem = linkItems.SingleOrDefault(x => x.SmiteId == item.RootItemId);

                updatedLinkItems.Add(new UpdateItemLinkDto
                {
                    Id = linkItem.Id,
                    ChildItemId = childItem?.Id,
                    RootItemId = rootItem?.Id
                });
            }

            await _maintainItemsRepository.UpdateItemLinksAsync(updatedLinkItems, cancellationToken);
        }

        public async Task LinkActivesAsync(IEnumerable<ItemDto> actives, CancellationToken cancellationToken = default)
        {
            var updatedLinkActives = new List<UpdateActiveLinkDto>();
            var linkActives = await _maintainItemsRepository.GetActivesForRelinkingAsync(cancellationToken);

            foreach (var linkActive in linkActives)
            {
                var active = actives.Single(x => x.ItemId == linkActive.SmiteId);
                var childActive = linkActives.SingleOrDefault(x => x.SmiteId == active.ChildItemId);
                var rootActive = linkActives.SingleOrDefault(x => x.SmiteId == active.RootItemId);

                updatedLinkActives.Add(new UpdateActiveLinkDto
                {
                    Id = linkActive.Id,
                    ChildActiveId = childActive?.Id,
                    RootActiveId = rootActive?.Id
                });
            }

            await _maintainItemsRepository.UpdateActiveLinksAsync(updatedLinkActives, cancellationToken);
        }

        private IEnumerable<CreateItemDescriptionDto> CreateItemDescriptions(IEnumerable<CommonItemDto> itemDescriptions)
        {
            var createdItemDescriptions = new List<CreateItemDescriptionDto>();
            foreach (var itemDescription in itemDescriptions)
            {
                createdItemDescriptions.Add(_mapperService.Map<CommonItemDto, CreateItemDescriptionDto>(itemDescription));
            }

            return createdItemDescriptions;
        }

        public Task<IEnumerable<ItemChecksumsDto>> GetItemChecksumsAsync(CancellationToken cancellationToken = default)
        {
            return _maintainItemsRepository.GetItemChecksumsDto(cancellationToken);
        }
    }
}
