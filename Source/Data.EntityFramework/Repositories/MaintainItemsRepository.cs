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

        public Task CreateActiveAsync(CreateActiveDto active, CancellationToken cancellationToken = default)
        {
            var activeEntity = _mapperService.Map<CreateActiveDto, Active>(active);
            _dbContext.Actives.Add(activeEntity);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task CreateConsumableAsync(CreateConsumableDto consumable, CancellationToken cancellationToken = default)
        {
            var consumableEntity = _mapperService.Map<CreateConsumableDto, Consumable>(consumable);
            _dbContext.Consumables.Add(consumableEntity);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task CreateItemAsync(CreateItemDto item, IEnumerable<CreateItemDescriptionDto> itemDescriptions, CancellationToken cancellationToken = default)
        {
            var itemEntity = _mapperService.Map<CreateItemDto, Item>(item);
            var itemDescriptionEntities = _mapperService.Map<IEnumerable<CreateItemDescriptionDto>, IEnumerable<ItemDescription>>(itemDescriptions);

            itemEntity.ItemDescriptions = itemDescriptionEntities;

            _dbContext.Items.Add(itemEntity);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<IEnumerable<ActiveLinkDto>> GetActiveLinksAsync(CancellationToken cancellationToken = default)
        {
            //TODO: need the patch entity so we can determine which actives to update
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemChecksumsDto>> GetItemChecksumsDto(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemLinkDto>> GetItemLinksAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
