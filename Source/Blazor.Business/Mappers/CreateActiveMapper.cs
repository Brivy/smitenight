using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Application.Blazor.Business.Mappers
{
    public class CreateActiveMapper : Mapper<ItemDto, CreateActiveDto>
    {
        private readonly IChecksumService _checksumService;

        public CreateActiveMapper(IChecksumService checksumService)
        {
            _checksumService = checksumService;
        }

        public override CreateActiveDto Map(ItemDto active)
        {
            var checksum = _checksumService.CalculateChecksum(active);
            return new CreateActiveDto
            {
                Checksum = checksum,
                Enabled = active.ActiveFlag == SmiteConstants.Yes,
                Description = !string.IsNullOrWhiteSpace(active.ItemDescription.Description) ? active.ItemDescription.Description : null,
                Name = active.DeviceName,
                ItemIconUrl = active.ItemIconUrl,
                ItemTier = ConvertToItemTierEnum(active.ItemTier),
                Price = active.Price,
                SecondaryDescription = active.ItemDescription.SecondaryDescription!, // Actives do always have a secondary description
                ShortDescription = active.ShortDesc,
                SmiteId = active.ItemId
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
    }
}
