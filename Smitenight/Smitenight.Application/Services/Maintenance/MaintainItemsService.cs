using Microsoft.EntityFrameworkCore;
using Smitenight.Abstractions.Application.Services.Maintenance;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.ItemRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses.ItemResponses;
using Smitenight.Domain.Constants.SmiteClient.Responses;
using Smitenight.Domain.Enums.Items;
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
                        .Include(x => x.RootItem)
                        .Include(x => x.ChildItem)
                        .SingleOrDefaultAsync(x => x.SmiteId == item.ItemId, cancellationToken);
                    if (existingItemEntity != null)
                    {
                        await UpdateItemAsync(existingItemEntity, item, cancellationToken);
                    }
                    else
                    {
                        AddItem(item);
                        onlyUpdates = false;
                    }
                }
                
                // Linking items is if new items are added, because we need to update the existing item tree
                // Need to save the changes so the Ids are available
                if (!onlyUpdates)
                {
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    await LinkItemsAsync(itemsResponse.Response, cancellationToken);
                }

                await _dbContext.SaveChangesAsync(cancellationToken);
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
        /// <returns></returns>
        private void AddItem(ItemsResponse item)
        {
            var itemEntity = BuildItemEntity(item);
            _dbContext.Items.Add(itemEntity);
        }

        /// <summary>
        /// Updates existing items and replacing their descriptions
        /// </summary>
        /// <param name="existingItem"></param>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task UpdateItemAsync(Item existingItem, ItemsResponse item, CancellationToken cancellationToken)
        {
            _dbContext.ItemDescriptions.RemoveRange(await _dbContext.ItemDescriptions.Where(x => x.ItemId == existingItem.Id).ToListAsync(cancellationToken));

            var itemEntity = BuildItemEntity(item);
            itemEntity.Id = existingItem.Id;
            itemEntity.RootItemId = existingItem.RootItemId;
            itemEntity.ChildItemId = existingItem.ChildItemId;
            _dbContext.Items.Update(itemEntity);
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
        }

        /// <summary>
        /// Builds a new item entity based on the response from the API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Item BuildItemEntity(ItemsResponse item)
        {
            return new Item
            {
                Enabled = item.ActiveFlag == ResponseConstants.Yes,
                Description = !string.IsNullOrWhiteSpace(item.ItemDescription.Description) ? item.ItemDescription.Description : null,
                Name = item.DeviceName,
                Glyph = item.Glyph == ResponseConstants.Yes,
                ItemIconUrl = item.ItemIconUrl,
                ItemTier = ConvertToItemTierEnum(item.ItemTier),
                Price = item.Price,
                RestrictedRoles = ConvertToRestrictedRolesEnum(item.RestrictedRoles),
                SecondaryDescription = !string.IsNullOrWhiteSpace(item.ItemDescription.SecondaryDescription) ? item.ItemDescription.SecondaryDescription : null,
                ShortDescription = !string.IsNullOrWhiteSpace(item.ShortDesc) ? item.ShortDesc : null,
                SmiteId = item.ItemId,
                StartingItem = item.StartingItem,
                ItemDescriptions = item.ItemDescription.MenuItems.Select(menuItem => new ItemDescription
                {
                    Description = menuItem.Description,
                    Value = menuItem.Value
                }).ToList()
            };
        }

        /// <summary>
        /// Converts an item tier integer to <see cref="ItemTierEnum"/>
        /// </summary>
        /// <param name="itemTier"></param>
        /// <returns></returns>
        private ItemTierEnum ConvertToItemTierEnum(int itemTier) => itemTier switch
        {
            ItemsResponseConstants.TierOneItem => ItemTierEnum.TierOne,
            ItemsResponseConstants.TierTwoItem => ItemTierEnum.TierTwo,
            ItemsResponseConstants.TierThreeItem => ItemTierEnum.TierThree,
            ItemsResponseConstants.TierFourItem => ItemTierEnum.TierFour,
            _ => ItemTierEnum.Unknown
        };

        /// <summary>
        /// Converts a restricted role string to <see cref="RestrictedRolesEnum"/>
        /// </summary>
        /// <param name="restrictedRole"></param>
        /// <returns></returns>
        private RestrictedRolesEnum ConvertToRestrictedRolesEnum(string restrictedRole) => restrictedRole switch
        {
            ItemsResponseConstants.NoRestrictionsRole => RestrictedRolesEnum.NoRestrictions,
            ItemsResponseConstants.HunterRestrictedRole => RestrictedRolesEnum.Hunter,
            ItemsResponseConstants.GuardianAndHunterAndMageRestrictedRole => RestrictedRolesEnum.GuardianAndHunterAndMage,
            ItemsResponseConstants.GuardianAndWarriorRestrictedRole => RestrictedRolesEnum.GuardianAndWarrior,
            ItemsResponseConstants.AssassinAndHunterAndMageRestrictedRole => RestrictedRolesEnum.AssassinAndHunterAndMage,
            ItemsResponseConstants.AssassinAndWarriorRestrictedRole => RestrictedRolesEnum.AssassinAndWarrior,
            ItemsResponseConstants.AssassinAndGuardianAndWarriorRestrictedRole => RestrictedRolesEnum.AssassinAndGuardianAndWarrior,
            _ => RestrictedRolesEnum.Unknown
        };

        /// <summary>
        /// Convert a item type string to <see cref="ItemTypeEnum"/>
        /// </summary>
        /// <param name="itemType"></param>
        /// <returns></returns>
        private ItemTypeEnum ConvertToItemTypeEnum(string itemType) => itemType switch
        {
            ItemsResponseConstants.ItemType => ItemTypeEnum.Item,
            ItemsResponseConstants.ConsumableItemType => ItemTypeEnum.Consumable,
            ItemsResponseConstants.ActiveItemType => ItemTypeEnum.Active,
            _ => ItemTypeEnum.Unknown
        };
    }
}
