using Microsoft.EntityFrameworkCore;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Persistence.Data.EntityFramework.Repositories
{
    public class MaintainItemsRepository : IMaintainItemsRepository
    {
        private readonly SmitenightDbContext _dbContext;
        private readonly IMapperService _mapperService;

        public MaintainItemsRepository(
            SmitenightDbContext smitenightDbContext,
            IMapperService mapperService)
        {
            _dbContext = smitenightDbContext;
            _mapperService = mapperService;
        }

        public async Task<int> CreateActiveAsync(CreateActiveDto active, CancellationToken cancellationToken = default)
        {
            var activeEntity = _mapperService.Map<CreateActiveDto, Active>(active);
            var patchId = await GetLatestPatchIdAsync(cancellationToken);

            activeEntity.PatchId = patchId;

            _dbContext.Actives.Add(activeEntity);

            var existingActive = await _dbContext.Actives.SingleOrDefaultAsync(x => x.SmiteId == active.SmiteId && x.Latest, cancellationToken);
            if (existingActive != null) existingActive.Latest = false;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return activeEntity.SmiteId;
        }

        public async Task<int> CreateConsumableAsync(CreateConsumableDto consumable, CancellationToken cancellationToken = default)
        {
            var consumableEntity = _mapperService.Map<CreateConsumableDto, Consumable>(consumable);
            var patchId = await GetLatestPatchIdAsync(cancellationToken);

            consumableEntity.PatchId = patchId;

            _dbContext.Consumables.Add(consumableEntity);

            var existingConsumable = await _dbContext.Consumables.SingleOrDefaultAsync(x => x.SmiteId == consumable.SmiteId && x.Latest, cancellationToken);
            if (existingConsumable != null) existingConsumable.Latest = false;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return consumableEntity.SmiteId;
        }

        public async Task<int> CreateItemAsync(CreateItemDto item, CancellationToken cancellationToken = default)
        {
            var itemEntity = _mapperService.Map<CreateItemDto, Item>(item);
            var patchId = await GetLatestPatchIdAsync(cancellationToken);

            itemEntity.PatchId = patchId;

            _dbContext.Items.Add(itemEntity);

            var existingItem = await _dbContext.Items.SingleOrDefaultAsync(x => x.SmiteId == item.SmiteId && x.Latest, cancellationToken);
            if (existingItem != null) existingItem.Latest = false;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return itemEntity.SmiteId;
        }

        public async Task<IEnumerable<ActiveLinkDto>> GetActivesForRelinkingAsync(IEnumerable<int> relinkNeededSmiteIds, CancellationToken cancellationToken = default)
        {
            var combinedActiveList = await _dbContext.Actives
                .AsNoTracking()
                .Where(x => relinkNeededSmiteIds.Contains(x.SmiteId))
                .GroupBy(x => x.SmiteId)
                .Select(x => x.OrderByDescending(y => y.Id).Take(2))
                .ToListAsync(cancellationToken);

            var relinkingActives = new List<ActiveLinkDto>();
            foreach (var actives in combinedActiveList)
            {
                Active? oldActive = null;
                var newActive = actives.First();
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

            var itemChecksums = await _dbContext.Items
                .Where(x => x.Latest)
                .Select(x => new ItemChecksumsDto
                {
                    ItemId = x.Id,
                    SmiteItemId = x.SmiteId,
                    Checksum = x.Checksum
                }).ToListAsync(cancellationToken);

            var activeChecksums = await _dbContext.Actives
                .Where(x => x.Latest)
                .Select(x => new ItemChecksumsDto
                {
                    ItemId = x.Id,
                    SmiteItemId = x.SmiteId,
                    Checksum = x.Checksum
                }).ToListAsync(cancellationToken);

            var consumableChecksums = await _dbContext.Consumables
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
            var combinedItemList = await _dbContext.Items
                .AsNoTracking()
                .Where(x => relinkNeededSmiteIds.Contains(x.SmiteId))
                .GroupBy(x => x.SmiteId)
                .Select(x => x.OrderByDescending(y => y.Id).Take(2))
                .ToListAsync(cancellationToken);

            var relinkingItems = new List<ItemLinkDto>();
            foreach (var items in combinedItemList)
            {
                Item? oldItem = null;
                var newItem = items.First();
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
            var actives = await _dbContext.Actives
                .Where(x => activeLinkIds.Contains(x.Id))
                .ToListAsync(cancellationToken);

            foreach (var active in actives)
            {
                var itemLink = activeLinks.First(x => x.Id == active.Id);
                active.ChildActiveId = itemLink.ChildActiveId;
                active.RootActiveId = itemLink.RootActiveId;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateItemLinksAsync(IEnumerable<UpdateItemLinkDto> itemLinks, CancellationToken cancellationToken = default)
        {
            var itemLinkIds = itemLinks.Select(y => y.Id).ToList();
            var items = await _dbContext.Items
                            .Where(x => itemLinkIds.Contains(x.Id))
                            .ToListAsync(cancellationToken);


            foreach (var item in items)
            {
                var itemLink = itemLinks.Single(x => x.Id == item.Id);
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
}
