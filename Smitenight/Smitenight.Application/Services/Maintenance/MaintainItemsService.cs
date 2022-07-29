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
        /// Adds new items (including actives and consumables) and updates all existing ones
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

        /// <summary>
        /// Process an <see cref="Item"/> based on the parameters from the SMITE API
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task ProcessItemAsync(ItemsResponse item, CancellationToken cancellationToken = default)
        {
            var itemEntity = BuildItemEntity(item);
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

        /// <summary>
        /// Process an <see cref="Consumable"/> based on the parameters from the SMITE API
        /// </summary>
        /// <param name="consumable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task ProcessConsumableAsync(ItemsResponse consumable, CancellationToken cancellationToken = default)
        {
            var consumableEntity = BuildConsumableEntity(consumable);
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

        /// <summary>
        /// Process an <see cref="Active"/> based on the parameters from the SMITE API
        /// </summary>
        /// <param name="active"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task ProcessActivesAsync(ItemsResponse active, CancellationToken cancellationToken = default)
        {
            var activeEntity = BuildActiveEntity(active);
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

        #region Builders

        /// <summary>
        /// Builds a new <see cref="Item"/> entity based on the response from the API
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
        /// Builds a new <see cref="Consumable"/> entity based on the response from the API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Consumable BuildConsumableEntity(ItemsResponse item)
        {
            return new Consumable
            {
                Enabled = item.ActiveFlag == ResponseConstants.Yes,
                Description = !string.IsNullOrWhiteSpace(item.ItemDescription.Description) ? item.ItemDescription.Description : null,
                Name = item.DeviceName,
                ItemIconUrl = item.ItemIconUrl,
                Price = item.Price,
                SecondaryDescription = !string.IsNullOrWhiteSpace(item.ItemDescription.SecondaryDescription) ? item.ItemDescription.SecondaryDescription : null,
                ShortDescription = !string.IsNullOrWhiteSpace(item.ShortDesc) ? item.ShortDesc : null,
                SmiteId = item.ItemId,
                ConsumableDescriptions = item.ItemDescription.MenuItems.Select(menuItem => new ConsumableDescription
                {
                    Description = menuItem.Description,
                    Value = menuItem.Value
                }).ToList()
            };
        }

        /// <summary>
        /// Builds a new <see cref="Active"/> entity based on the response from the API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Active BuildActiveEntity(ItemsResponse item)
        {
            return new Active
            {
                Enabled = item.ActiveFlag == ResponseConstants.Yes,
                Description = !string.IsNullOrWhiteSpace(item.ItemDescription.Description) ? item.ItemDescription.Description : null,
                Name = item.DeviceName,
                ItemIconUrl = item.ItemIconUrl,
                ItemTier = ConvertToItemTierEnum(item.ItemTier),
                Price = item.Price,
                SecondaryDescription = item.ItemDescription.SecondaryDescription!, // Actives do always have a secondary description
                ShortDescription = item.ShortDesc,
                SmiteId = item.ItemId
            };
        }

        #endregion

        #region Converters

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

        #endregion
    }
}
