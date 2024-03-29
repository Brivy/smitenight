﻿using Smitenight.Application.Core.Business.Contracts.Services.Checksums;
using Smitenight.Application.Core.Business.Contracts.Services.Maintenance;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Utilities.Mapper.Services;

namespace Smitenight.Application.Core.Business.Services.Maintenance;

internal class MaintainItemsService(
    IMaintainItemsRepository maintainItemsRepository,
    IChecksumService checksumService,
    IMapperService mapperService) : IMaintainItemsService
{
    private readonly IMaintainItemsRepository _maintainItemsRepository = maintainItemsRepository;
    private readonly IChecksumService _checksumService = checksumService;
    private readonly IMapperService _mapperService = mapperService;

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
                CreateItemDto createdItem = _mapperService.Map<ItemDto, CreateItemDto>(item);
                return _maintainItemsRepository.CreateItemAsync(createdItem, cancellationToken);
            case ItemConstants.ActiveItemType:
                CreateActiveDto createdActive = _mapperService.Map<ItemDto, CreateActiveDto>(item);
                return _maintainItemsRepository.CreateActiveAsync(createdActive, cancellationToken);
            case ItemConstants.ConsumableItemType:
                CreateConsumableDto createdConsumable = _mapperService.Map<ItemDto, CreateConsumableDto>(item);
                return _maintainItemsRepository.CreateConsumableAsync(createdConsumable, cancellationToken);
            default:
                throw new NotImplementedException($"Specified {item.Type} can not be processed");
        }
    }

    public async Task LinkItemsAsync(IEnumerable<ItemDto> items, IEnumerable<int> relinkNeededSmiteIds, CancellationToken cancellationToken = default)
    {
        var updatedLinkItems = new List<UpdateItemLinkDto>();
        IEnumerable<ItemLinkDto> linkItems = await _maintainItemsRepository.GetItemForRelinkingAsync(relinkNeededSmiteIds, cancellationToken);
        foreach (ItemLinkDto linkItem in linkItems)
        {
            ItemDto item = items.Single(x => x.ItemId == linkItem.SmiteId);
            int? childItemId = linkItems.SingleOrDefault(x => x.SmiteId == item.ChildItemId)?.NewItemId;
            int? rootItemId = linkItems.SingleOrDefault(x => x.SmiteId == item.RootItemId)?.NewItemId;

            // If an item has an older version, we need to check if the child and root items are also updated
            if (linkItem.OldItemId.HasValue)
            {
                childItemId = linkItems.SingleOrDefault(x => x.OldItemId == linkItem.ChildItemId)?.NewItemId ?? linkItem.ChildItemId;
                rootItemId = linkItems.SingleOrDefault(x => x.OldItemId == linkItem.RootItemId)?.NewItemId ?? linkItem.RootItemId;
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
        IEnumerable<ActiveLinkDto> linkActives = await _maintainItemsRepository.GetActivesForRelinkingAsync(relinkNeededSmiteIds, cancellationToken);
        foreach (ActiveLinkDto linkActive in linkActives)
        {
            ItemDto item = actives.Single(x => x.ItemId == linkActive.SmiteId);
            int? childActiveId = linkActives.SingleOrDefault(x => x.SmiteId == item.ChildItemId)?.NewItemId;
            int? rootActiveId = linkActives.SingleOrDefault(x => x.SmiteId == item.RootItemId)?.NewItemId;

            // If an active has an older version, we need to check if the child and root actives are also updated
            if (linkActive.OldItemId.HasValue)
            {
                childActiveId = linkActives.SingleOrDefault(x => x.OldItemId == linkActive.ChildActiveId)?.NewItemId ?? linkActive.ChildActiveId;
                rootActiveId = linkActives.SingleOrDefault(x => x.OldItemId == linkActive.RootActiveId)?.NewItemId ?? linkActive.RootActiveId;
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
