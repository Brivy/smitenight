using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateItemMapper : Mapper<ItemDto, CreateItemDto>
    {
        public override CreateItemDto Map(ItemDto item)
        {
            return new CreateItemDto
            {
                Enabled = item.ActiveFlag == SmiteConstants.Yes,
                Description = !string.IsNullOrWhiteSpace(item.ItemDescription.Description) ? item.ItemDescription.Description : null,
                Name = item.DeviceName,
                Glyph = item.Glyph == SmiteConstants.Yes,
                ItemIconUrl = item.ItemIconUrl,
                ItemTier = ConvertToItemTierEnum(item.ItemTier),
                Price = item.Price,
                RestrictedRoles = ConvertToRestrictedRolesEnum(item.RestrictedRoles),
                SecondaryDescription = !string.IsNullOrWhiteSpace(item.ItemDescription.SecondaryDescription) ? item.ItemDescription.SecondaryDescription : null,
                ShortDescription = !string.IsNullOrWhiteSpace(item.ShortDesc) ? item.ShortDesc : null,
                SmiteId = item.ItemId,
                StartingItem = item.StartingItem
            };
        }

        private static ItemTier ConvertToItemTierEnum(int itemTier) => itemTier switch
        {
            ItemConstants.TierOneItem => ItemTier.TierOne,
            ItemConstants.TierTwoItem => ItemTier.TierTwo,
            ItemConstants.TierThreeItem => ItemTier.TierThree,
            ItemConstants.TierFourItem => ItemTier.TierFour,
            _ => ItemTier.Unknown
        };

        private static RestrictedRoles ConvertToRestrictedRolesEnum(string restrictedRole) => restrictedRole switch
        {
            ItemConstants.NoRestrictionsRole => RestrictedRoles.NoRestrictions,
            ItemConstants.HunterRestrictedRole => RestrictedRoles.Hunter,
            ItemConstants.GuardianAndHunterAndMageRestrictedRole => RestrictedRoles.GuardianAndHunterAndMage,
            ItemConstants.GuardianAndWarriorRestrictedRole => RestrictedRoles.GuardianAndWarrior,
            ItemConstants.AssassinAndHunterAndMageRestrictedRole => RestrictedRoles.AssassinAndHunterAndMage,
            ItemConstants.AssassinAndWarriorRestrictedRole => RestrictedRoles.AssassinAndWarrior,
            ItemConstants.AssassinAndGuardianAndWarriorRestrictedRole => RestrictedRoles.AssassinAndGuardianAndWarrior,
            _ => RestrictedRoles.Unknown
        };
    }
}
