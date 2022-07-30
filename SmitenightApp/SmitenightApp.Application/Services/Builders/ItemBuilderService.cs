using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.ItemResponses;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Enums.Items;
using SmitenightApp.Domain.Models.Items;
using ItemDescription = SmitenightApp.Domain.Models.Items.ItemDescription;

namespace SmitenightApp.Application.Services.Builders
{
    public class ItemBuilderService : IItemBuilderService
    {
        /// <summary>
        /// Builds a new <see cref="Item"/> entity based on the response from the API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Item BuildItem(ItemsResponse item)
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
        public Consumable BuildConsumable(ItemsResponse item)
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
        public Active BuildActive(ItemsResponse item)
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
