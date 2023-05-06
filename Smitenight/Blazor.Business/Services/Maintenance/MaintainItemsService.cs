using Microsoft.EntityFrameworkCore;
using Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;
using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Domain.Models.Constants.SmiteClient.Responses;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Persistence.Data.EntityFramework;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public class MaintainItemsService : IMaintainItemsService
    {
        private readonly SmitenightDbContext _dbContext;
        private readonly IItemSmiteClientFacade _itemSmiteClient;
        private readonly IItemBuilderService _itemBuilderService;

        public MaintainItemsService(SmitenightDbContext dbContext,
            IItemSmiteClientFacade itemSmiteClient,
            IItemBuilderService itemBuilderService)
        {
            _dbContext = dbContext;
            _itemSmiteClient = itemSmiteClient;
            _itemBuilderService = itemBuilderService;
        }

        public async Task MaintainAsync(CancellationToken cancellationToken = default)
        {
            var itemsResponse = await _itemSmiteClient.GetItemsAsync(LanguageCodeEnum.English, cancellationToken);
            if (itemsResponse?.Response == null)
            {
                return;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var itemsModified = false;
                var activesModified = false;
                foreach (var item in itemsResponse.Response)
                {
                    switch (item.Type)
                    {
                        case ItemsResponseConstants.ItemType:
                            await ProcessItemAsync(item, cancellationToken);
                            itemsModified = true;
                            break;
                        case ItemsResponseConstants.ConsumableItemType:
                            await ProcessConsumableAsync(item, cancellationToken);
                            break;
                        case ItemsResponseConstants.ActiveItemType:
                            await ProcessActivesAsync(item, cancellationToken);
                            activesModified = true;
                            break;
                    }
                }

                await _dbContext.SaveChangesAsync(cancellationToken);

                if (itemsModified)
                {
                    var allItems = itemsResponse.Response.Where(x => x.Type == ItemsResponseConstants.ItemType).ToList();
                    await LinkItemsAsync(allItems, cancellationToken);
                }

                if (activesModified)
                {
                    var allActives = itemsResponse.Response.Where(x => x.Type == ItemsResponseConstants.ActiveItemType).ToList();
                    await LinkActivesAsync(allActives, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #region Processing

        private async Task ProcessItemAsync(ItemsResponse item, CancellationToken cancellationToken = default)
        {
            var itemEntity = _itemBuilderService.BuildItem(item);
            var existingItemEntity = await _dbContext.Items
                .AsNoTracking()
                .Include(x => x.ItemDescriptions)
                .Include(x => x.RootItem)
                .Include(x => x.ChildItem)
                .SingleOrDefaultAsync(x => x.SmiteId == item.ItemId, cancellationToken);

            if (existingItemEntity == null)
            {
                _dbContext.Items.Add(itemEntity);
            }
            else
            {
                var oldItemDescriptions = await _dbContext.ItemDescriptions.Where(x => x.ItemId == existingItemEntity.Id).ToListAsync(cancellationToken);
                _dbContext.ItemDescriptions.RemoveRange(oldItemDescriptions);

                itemEntity.Id = existingItemEntity.Id;
                itemEntity.RootItemId = existingItemEntity.RootItemId;
                itemEntity.ChildItemId = existingItemEntity.ChildItemId;
                _dbContext.Items.Update(itemEntity);
            }
        }

        private async Task ProcessConsumableAsync(ItemsResponse consumable, CancellationToken cancellationToken = default)
        {
            var consumableEntity = _itemBuilderService.BuildConsumable(consumable);
            var existingConsumableEntity = await _dbContext.Consumables
                .AsNoTracking()
                .Include(x => x.ConsumableDescriptions)
                .SingleOrDefaultAsync(x => x.SmiteId == consumable.ItemId, cancellationToken);

            if (existingConsumableEntity == null)
            {
                _dbContext.Consumables.Add(consumableEntity);
            }
            else
            {
                var oldConsumableDescriptions = await _dbContext.ConsumableDescriptions.Where(x => x.ConsumableId == existingConsumableEntity.Id).ToListAsync(cancellationToken);
                _dbContext.ConsumableDescriptions.RemoveRange(oldConsumableDescriptions);

                consumableEntity.Id = existingConsumableEntity.Id;
                _dbContext.Consumables.Update(consumableEntity);
            }
        }

        private async Task ProcessActivesAsync(ItemsResponse active, CancellationToken cancellationToken = default)
        {
            var activeEntity = _itemBuilderService.BuildActive(active);
            var existingActiveEntity = await _dbContext.Actives
                .AsNoTracking()
                .Include(x => x.RootActive)
                .Include(x => x.ChildActive)
                .SingleOrDefaultAsync(x => x.SmiteId == active.ItemId, cancellationToken);

            if (existingActiveEntity == null)
            {
                _dbContext.Actives.Add(activeEntity);
            }
            else
            {
                activeEntity.Id = existingActiveEntity.Id;
                activeEntity.RootActiveId = existingActiveEntity.RootActiveId;
                activeEntity.ChildActiveId = existingActiveEntity.ChildActiveId;
                _dbContext.Actives.Update(activeEntity);
            }
        }

        #endregion

        #region Linking

        /// <summary>
        /// Link the items with each other to create an item tree
        /// </summary>
        /// <param name="items"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task LinkItemsAsync(List<ItemsResponse> items, CancellationToken cancellationToken)
        {
            var itemEntities = await _dbContext.Items.ToListAsync(cancellationToken);
            foreach (var itemEntity in itemEntities)
            {
                var item = items.Single(x => x.ItemId == itemEntity.SmiteId);

                var childItemEntity = await _dbContext.Items.SingleOrDefaultAsync(x => x.SmiteId == item.ChildItemId, cancellationToken);
                itemEntity.ChildItemId = childItemEntity?.Id;

                var rootItemEntity = await _dbContext.Items.SingleOrDefaultAsync(x => x.SmiteId == item.RootItemId, cancellationToken);
                itemEntity.RootItemId = rootItemEntity?.Id;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Link the actives with each other to create an active tree
        /// </summary>
        /// <param name="actives"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task LinkActivesAsync(List<ItemsResponse> actives, CancellationToken cancellationToken)
        {
            var activeEntities = await _dbContext.Actives.ToListAsync(cancellationToken);
            foreach (var activeEntity in activeEntities)
            {
                var active = actives.Single(x => x.ItemId == activeEntity.SmiteId);

                Console.WriteLine(active.ChildItemId);
                var childActiveEntity = await _dbContext.Actives.SingleOrDefaultAsync(x => x.SmiteId == active.ChildItemId, cancellationToken);
                activeEntity.ChildActiveId = childActiveEntity?.Id;

                Console.WriteLine(active.RootItemId);
                var rootActiveEntity = await _dbContext.Actives.SingleOrDefaultAsync(x => x.SmiteId == active.RootItemId, cancellationToken);
                activeEntity.RootActiveId = rootActiveEntity?.Id;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}
