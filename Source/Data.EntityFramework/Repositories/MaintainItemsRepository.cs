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
            _dbContext.Actives.Add(activeEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return activeEntity.Id;
        }

        public async Task<int> CreateConsumableAsync(CreateConsumableDto consumable, CancellationToken cancellationToken = default)
        {
            var consumableEntity = _mapperService.Map<CreateConsumableDto, Consumable>(consumable);
            _dbContext.Consumables.Add(consumableEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return consumableEntity.Id;
        }

        public async Task<int> CreateItemAsync(CreateItemDto item, IEnumerable<CreateItemDescriptionDto> itemDescriptions, CancellationToken cancellationToken = default)
        {
            var itemEntity = _mapperService.Map<CreateItemDto, Item>(item);
            var itemDescriptionEntities = _mapperService.Map<IEnumerable<CreateItemDescriptionDto>, IEnumerable<ItemDescription>>(itemDescriptions);

            itemEntity.ItemDescriptions = itemDescriptionEntities;

            _dbContext.Items.Add(itemEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return itemEntity.Id;
        }

        public async Task<IEnumerable<ActiveLinkDto>> GetActivesForRelinkingAsync(IEnumerable<int> relinkNeededActiveIds, CancellationToken cancellationToken = default)
        {
            var activeDictionary = await _dbContext.Actives
                .AsNoTracking()
                .Where(x => relinkNeededActiveIds.Contains(x.SmiteId))
                .GroupBy(x => x.SmiteId)
                .SelectMany(x => x.OrderByDescending(y => y.Id).Take(2))
                .GroupBy(x => x.SmiteId)
                .ToDictionaryAsync(x => x.Key, x => x.Select(y => y).ToList(), cancellationToken);

            var relinkingActives = new List<ActiveLinkDto>();
            foreach (var activeKvp in activeDictionary)
            {
                var newActive = activeKvp.Value[0];
                var oldActive = activeKvp.Value[1];
                relinkingActives.Add(new ActiveLinkDto
                {
                    OldItemId = activeKvp.Value.Count == 2 ? oldActive.Id : null,
                    NewItemId = newActive.Id,
                    SmiteId = activeKvp.Key,
                    ChildActiveId = newActive.ChildActiveId,
                    RootActiveId = newActive.RootActiveId
                });
            }

            return relinkingActives;
        }

        public Task<IEnumerable<ItemChecksumsDto>> GetItemChecksumsDto(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ItemLinkDto>> GetItemForRelinkingAsync(IEnumerable<int> relinkNeededItemIds, CancellationToken cancellationToken = default)
        {
            var itemDictionary = await _dbContext.Items
                .AsNoTracking()
                .Where(x => relinkNeededItemIds.Contains(x.SmiteId))
                .GroupBy(x => x.SmiteId)
                .SelectMany(x => x.OrderByDescending(y => y.Id).Take(2))
                .GroupBy(x => x.SmiteId)
                .ToDictionaryAsync(x => x.Key, x => x.Select(y => y).ToList(), cancellationToken);

            var relinkingItems = new List<ItemLinkDto>();
            foreach (var itemKvp in itemDictionary)
            {
                var newItem = itemKvp.Value[0];
                var oldItem = itemKvp.Value[1];
                relinkingItems.Add(new ItemLinkDto
                {
                    OldItemId = itemKvp.Value.Count == 2 ? oldItem.Id : null,
                    NewItemId = newItem.Id,
                    SmiteId = itemKvp.Key,
                    ChildItemId = newItem.ChildItemId,
                    RootItemId = newItem.RootItemId
                });
            }

            return relinkingItems;
        }

        public Task UpdateActiveLinksAsync(IEnumerable<UpdateActiveLinkDto> itemLinks, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemLinksAsync(IEnumerable<UpdateItemLinkDto> itemLinks, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
