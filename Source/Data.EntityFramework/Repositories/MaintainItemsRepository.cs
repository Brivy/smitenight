using Microsoft.EntityFrameworkCore;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Services;

namespace Smitenight.Persistence.Data.EntityFramework.Repositories;

public class MaintainItemsRepository(
    SmitenightDbContext smitenightDbContext,
    IMapperService mapperService) : IMaintainItemsRepository
{
    private readonly SmitenightDbContext _dbContext = smitenightDbContext;
    private readonly IMapperService _mapperService = mapperService;

    public async Task<int> CreateActiveAsync(CreateActiveDto active, CancellationToken cancellationToken = default)
    {
        Active activeEntity = _mapperService.Map<CreateActiveDto, Active>(active);
        int patchId = await GetLatestPatchIdAsync(cancellationToken);

        activeEntity.PatchId = patchId;

        _dbContext.Actives.Add(activeEntity);

        Active? existingActive = await _dbContext.Actives.SingleOrDefaultAsync(x => x.SmiteId == active.SmiteId && x.Latest, cancellationToken);
        if (existingActive != null) existingActive.Latest = false;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return activeEntity.SmiteId;
    }

    public async Task<int> CreateConsumableAsync(CreateConsumableDto consumable, CancellationToken cancellationToken = default)
    {
        Consumable consumableEntity = _mapperService.Map<CreateConsumableDto, Consumable>(consumable);
        int patchId = await GetLatestPatchIdAsync(cancellationToken);

        consumableEntity.PatchId = patchId;

        _dbContext.Consumables.Add(consumableEntity);

        Consumable? existingConsumable = await _dbContext.Consumables.SingleOrDefaultAsync(x => x.SmiteId == consumable.SmiteId && x.Latest, cancellationToken);
        if (existingConsumable != null) existingConsumable.Latest = false;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return consumableEntity.SmiteId;
    }

    public async Task<int> CreateItemAsync(CreateItemDto item, CancellationToken cancellationToken = default)
    {
        Item itemEntity = _mapperService.Map<CreateItemDto, Item>(item);
        int patchId = await GetLatestPatchIdAsync(cancellationToken);

        itemEntity.PatchId = patchId;

        _dbContext.Items.Add(itemEntity);

        Item? existingItem = await _dbContext.Items.SingleOrDefaultAsync(x => x.SmiteId == item.SmiteId && x.Latest, cancellationToken);
        if (existingItem != null) existingItem.Latest = false;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return itemEntity.SmiteId;
    }

    public async Task<IEnumerable<ActiveLinkDto>> GetActivesForRelinkingAsync(IEnumerable<int> relinkNeededSmiteIds, CancellationToken cancellationToken = default)
    {
        List<IEnumerable<Active>> combinedActiveList = await _dbContext.Actives
            .AsNoTracking()
            .Where(x => relinkNeededSmiteIds.Contains(x.SmiteId))
            .GroupBy(x => x.SmiteId)
            .Select(x => x.OrderByDescending(y => y.Id).Take(2))
            .ToListAsync(cancellationToken);

        var relinkingActives = new List<ActiveLinkDto>();
        foreach (IEnumerable<Active>? actives in combinedActiveList)
        {
            Active? oldActive = null;
            Active newActive = actives.First();
            if (actives.Count() == 2) oldActive = actives.Last();

            relinkingActives.Add(new ActiveLinkDto
            {
                OldItemId = oldActive?.Id,
                NewItemId = newActive.Id,
                SmiteId = newActive.SmiteId,
                ChildActiveId = oldActive?.ChildActiveId,
                RootActiveId = oldActive?.RootActiveId
            });
        }

        return relinkingActives;
    }

    public async Task<IEnumerable<ItemChecksumsDto>> GetItemChecksumsDto(CancellationToken cancellationToken = default)
    {
        var checksums = new List<ItemChecksumsDto>();

        List<ItemChecksumsDto> itemChecksums = await _dbContext.Items
            .Where(x => x.Latest)
            .Select(x => new ItemChecksumsDto
            {
                ItemId = x.Id,
                SmiteItemId = x.SmiteId,
                Checksum = x.Checksum
            }).ToListAsync(cancellationToken);

        List<ItemChecksumsDto> activeChecksums = await _dbContext.Actives
            .Where(x => x.Latest)
            .Select(x => new ItemChecksumsDto
            {
                ItemId = x.Id,
                SmiteItemId = x.SmiteId,
                Checksum = x.Checksum
            }).ToListAsync(cancellationToken);

        List<ItemChecksumsDto> consumableChecksums = await _dbContext.Consumables
            .Where(x => x.Latest)
            .Select(x => new ItemChecksumsDto
            {
                ItemId = x.Id,
                SmiteItemId = x.SmiteId,
                Checksum = x.Checksum
            }).ToListAsync(cancellationToken);

        checksums.AddRange(itemChecksums);
        checksums.AddRange(activeChecksums);
        checksums.AddRange(consumableChecksums);
        return checksums;
    }

    public async Task<IEnumerable<ItemLinkDto>> GetItemForRelinkingAsync(IEnumerable<int> relinkNeededSmiteIds, CancellationToken cancellationToken = default)
    {
        List<IEnumerable<Item>> combinedItemList = await _dbContext.Items
            .AsNoTracking()
            .Where(x => relinkNeededSmiteIds.Contains(x.SmiteId))
            .GroupBy(x => x.SmiteId)
            .Select(x => x.OrderByDescending(y => y.Id).Take(2))
            .ToListAsync(cancellationToken);

        var relinkingItems = new List<ItemLinkDto>();
        foreach (IEnumerable<Item> items in combinedItemList)
        {
            Item? oldItem = null;
            Item newItem = items.First();
            if (items.Count() == 2) oldItem = items.Last();

            relinkingItems.Add(new ItemLinkDto
            {
                OldItemId = oldItem?.Id,
                NewItemId = newItem.Id,
                SmiteId = newItem.SmiteId,
                ChildItemId = oldItem?.ChildItemId,
                RootItemId = oldItem?.RootItemId
            });
        }

        return relinkingItems;
    }

    public async Task UpdateActiveLinksAsync(IEnumerable<UpdateActiveLinkDto> activeLinks, CancellationToken cancellationToken = default)
    {
        var activeLinkIds = activeLinks.Select(y => y.Id).ToList();
        List<Active> actives = await _dbContext.Actives
            .Where(x => activeLinkIds.Contains(x.Id))
            .ToListAsync(cancellationToken);

        foreach (Active? active in actives)
        {
            UpdateActiveLinkDto itemLink = activeLinks.First(x => x.Id == active.Id);
            active.ChildActiveId = itemLink.ChildActiveId;
            active.RootActiveId = itemLink.RootActiveId;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateItemLinksAsync(IEnumerable<UpdateItemLinkDto> itemLinks, CancellationToken cancellationToken = default)
    {
        var itemLinkIds = itemLinks.Select(y => y.Id).ToList();
        List<Item> items = await _dbContext.Items
                        .Where(x => itemLinkIds.Contains(x.Id))
                        .ToListAsync(cancellationToken);


        foreach (Item? item in items)
        {
            UpdateItemLinkDto itemLink = itemLinks.Single(x => x.Id == item.Id);
            item.ChildItemId = itemLink.ChildItemId;
            item.RootItemId = itemLink.RootItemId;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private Task<int> GetLatestPatchIdAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.Patches
            .OrderByDescending(x => x.ReleaseDate)
            .Select(x => x.Id)
            .FirstAsync(cancellationToken);
    }
}
