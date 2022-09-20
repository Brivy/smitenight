using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Domain.Clients.ItemClient;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Enums.Items;
using SmitenightApp.Domain.Models.Items;
using ItemDescription = SmitenightApp.Domain.Models.Items.ItemDescription;

namespace SmitenightApp.Application.Services.Builders
{
    public class ItemBuilderService : IItemBuilderService
    {
        public Item BuildItem(ItemsResponse itemResponse)
        {
            return new Item
            {
                Enabled = itemResponse.ActiveFlag == ResponseConstants.Yes,
                Description = !string.IsNullOrWhiteSpace(itemResponse.ItemDescription.Description) ? itemResponse.ItemDescription.Description : null,
                Name = itemResponse.DeviceName,
                Glyph = itemResponse.Glyph == ResponseConstants.Yes,
                ItemIconUrl = itemResponse.ItemIconUrl,
                ItemTier = ConvertToItemTierEnum(itemResponse.ItemTier),
                Price = itemResponse.Price,
                RestrictedRoles = ConvertToRestrictedRolesEnum(itemResponse.RestrictedRoles),
                SecondaryDescription = !string.IsNullOrWhiteSpace(itemResponse.ItemDescription.SecondaryDescription) ? itemResponse.ItemDescription.SecondaryDescription : null,
                ShortDescription = !string.IsNullOrWhiteSpace(itemResponse.ShortDesc) ? itemResponse.ShortDesc : null,
                SmiteId = itemResponse.ItemId,
                StartingItem = itemResponse.StartingItem,
                ItemDescriptions = itemResponse.ItemDescription.MenuItems.Select(menuItem => new ItemDescription
                {
                    Description = menuItem.Description,
                    Value = menuItem.Value
                }).ToList()
            };
        }

        public Consumable BuildConsumable(ItemsResponse consumableResponse)
        {
            return new Consumable
            {
                Enabled = consumableResponse.ActiveFlag == ResponseConstants.Yes,
                Description = !string.IsNullOrWhiteSpace(consumableResponse.ItemDescription.Description) ? consumableResponse.ItemDescription.Description : null,
                Name = consumableResponse.DeviceName,
                ItemIconUrl = consumableResponse.ItemIconUrl,
                Price = consumableResponse.Price,
                SecondaryDescription = !string.IsNullOrWhiteSpace(consumableResponse.ItemDescription.SecondaryDescription) ? consumableResponse.ItemDescription.SecondaryDescription : null,
                ShortDescription = !string.IsNullOrWhiteSpace(consumableResponse.ShortDesc) ? consumableResponse.ShortDesc : null,
                SmiteId = consumableResponse.ItemId,
                ConsumableDescriptions = consumableResponse.ItemDescription.MenuItems.Select(menuItem => new ConsumableDescription
                {
                    Description = menuItem.Description,
                    Value = menuItem.Value
                }).ToList()
            };
        }

        public Active BuildActive(ItemsResponse activeResponse)
        {
            return new Active
            {
                Enabled = activeResponse.ActiveFlag == ResponseConstants.Yes,
                Description = !string.IsNullOrWhiteSpace(activeResponse.ItemDescription.Description) ? activeResponse.ItemDescription.Description : null,
                Name = activeResponse.DeviceName,
                ItemIconUrl = activeResponse.ItemIconUrl,
                ItemTier = ConvertToItemTierEnum(activeResponse.ItemTier),
                Price = activeResponse.Price,
                SecondaryDescription = activeResponse.ItemDescription.SecondaryDescription!, // Actives do always have a secondary description
                ShortDescription = activeResponse.ShortDesc,
                SmiteId = activeResponse.ItemId
            };
        }

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
