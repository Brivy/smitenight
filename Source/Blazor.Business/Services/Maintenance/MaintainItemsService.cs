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

        public async Task MaintainItemAsync(ItemDto item, string checksum, CancellationToken cancellationToken = default)
        {
            if (!_checksumService.IsChecksumDifferent(checksum, item))
            {
                return;
            }

            await CreateItemAsync(item, cancellationToken);
        }

        public async Task CreateItemAsync(ItemDto item, CancellationToken cancellationToken = default)
        {
            switch (item.Type)
            {
                case ItemConstants.ItemType:
                    var createdItem = _mapperService.Map<ItemDto, CreateItemDto>(item);
                    var createdItemDescriptions = CreateItemDescriptions(item.ItemDescription.MenuItems);
                    await _maintainItemsRepository.CreateItemAsync(createdItem, createdItemDescriptions, cancellationToken);
                    break;
                case ItemConstants.ConsumableItemType:
                    var createdActive = _mapperService.Map<ItemDto, CreateActiveDto>(item);
                    await _maintainItemsRepository.CreateActiveAsync(createdActive, cancellationToken);
                    break;
                case ItemConstants.ActiveItemType:
                    var createdConsumable = _mapperService.Map<ItemDto, CreateConsumableDto>(item);
                    await _maintainItemsRepository.CreateConsumableAsync(createdConsumable, cancellationToken);
                    break;
            }
        }

        public async Task LinkItemsAsync(IEnumerable<ItemDto> items, CancellationToken cancellationToken = default)
        {
            var updatedLinkItems = new List<UpdateItemLinkDto>();
            var linkItems = await _maintainItemsRepository.GetItemLinksAsync(cancellationToken);

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
            var linkActives = await _maintainItemsRepository.GetActiveLinksAsync(cancellationToken);

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

        private IEnumerable<CreateItemDescriptionDto> CreateItemDescriptions(IEnumerable<MenuItemDto> itemDescriptions)
        {
            var createdItemDescriptions = new List<CreateItemDescriptionDto>();
            foreach (var itemDescription in itemDescriptions)
            {
                createdItemDescriptions.Add(_mapperService.Map<MenuItemDto, CreateItemDescriptionDto>(itemDescription));
            }

            return createdItemDescriptions;
        }

        public Task<IEnumerable<ItemChecksumsDto>> GetItemChecksumsAsync(CancellationToken cancellationToken = default)
        {
            return _maintainItemsRepository.GetItemChecksumsDto(cancellationToken);
        }
    }
}
