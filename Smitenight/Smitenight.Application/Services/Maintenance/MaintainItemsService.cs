using Microsoft.EntityFrameworkCore;
using Smitenight.Abstractions.Application.Services.Maintenance;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.ItemRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses.ItemResponses;
using Smitenight.Domain.Enums.SmiteClient;
using Smitenight.Domain.Models.Items;
using Smitenight.Persistence;
using ItemDescription = Smitenight.Domain.Models.Items.ItemDescription;

namespace Smitenight.Application.Services.Maintenance
{
    public class MaintainItemsService : IMaintainItemsService
    {
        private readonly SmitenightDbContext _dbContext;
        private readonly IItemSmiteClient _itemSmiteClient;

        public MaintainItemsService(SmitenightDbContext dbContext,
            IItemSmiteClient itemSmiteClient)
        {
            _dbContext = dbContext;
            _itemSmiteClient = itemSmiteClient;
        }

        /// <summary>
        /// Adds new items and updates all existing ones
        /// This includes the item descriptions
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task MaintainAsync(string sessionId, CancellationToken cancellationToken = default)
        {
            var itemsRequest = new ItemsRequest(sessionId, LanguageCodeEnum.English);
            var itemsResponse = await _itemSmiteClient.GetItemsAsync(itemsRequest, cancellationToken);
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
                var onlyUpdates = true;
                foreach (var item in itemsResponse.Response)
                {
                    var existingItemEntity = await _dbContext.Items
                        .AsNoTracking()
                        .Include(x => x.ItemDescriptions)
                        .SingleOrDefaultAsync(x => x.SmiteId == item.ItemId, cancellationToken);
                    if (existingItemEntity != null)
                    {
                        await UpdateItemsAsync(existingItemEntity, item, cancellationToken);
                    }
                    else
                    {
                        await AddItemsAsync(item, cancellationToken);
                        onlyUpdates = false;
                    }
                }

                // Linking items is if new items are added, because we need to update the existing item tree
                if (!onlyUpdates)
                {
                    await LinkItemsAsync(itemsResponse.Response, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Starts adding new items and their descriptions to the database
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task AddItemsAsync(ItemsResponse item, CancellationToken cancellationToken)
        {
            var itemEntity = BuildItemEntity(item);
            _dbContext.Items.Add(itemEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Updates existing items and replacing their descriptions
        /// </summary>
        /// <param name="existingItem"></param>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task UpdateItemsAsync(Item existingItem, ItemsResponse item, CancellationToken cancellationToken)
        {
            _dbContext.ItemDescriptions.RemoveRange(await _dbContext.ItemDescriptions.Where(x => x.ItemId == existingItem.Id).ToListAsync(cancellationToken));
            await _dbContext.SaveChangesAsync(cancellationToken);

            var itemEntity = BuildItemEntity(item);
            itemEntity.Id = existingItem.Id;
            _dbContext.Items.Update(itemEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

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

        private Item BuildItemEntity(ItemsResponse item)
        {
            return new Item
            {
                ActiveFlag = item.ActiveFlag,
                Description = item.ItemDescription.Description,
                DeviceName = item.DeviceName,
                Glyph = item.Glyph,
                ItemIconUrl = item.ItemIconUrl,
                ItemTier = item.ItemTier,
                Price = item.Price,
                RestrictedRoles = item.RestrictedRoles,
                SecondaryDescription = item.ItemDescription.SecondaryDescription,
                ShortDescription = item.ShortDesc,
                SmiteId = item.ItemId,
                StartingItem = item.StartingItem,
                Type = item.Type,
                ItemDescriptions = item.ItemDescription.MenuItems.Select(menuItem => new ItemDescription
                {
                    Description = menuItem.Description,
                    Value = menuItem.Value
                }).ToList()
            };
        }
    }
}
