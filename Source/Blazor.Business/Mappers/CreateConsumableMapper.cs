using Smitenight.Application.Core.Business.Contracts.Services.Checksums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Application.Core.Business.Mappers;

public class CreateConsumableMapper(IChecksumService checksumService) : Mapper<ItemDto, CreateConsumableDto>
{
    private readonly IChecksumService _checksumService = checksumService;

    public override CreateConsumableDto Map(ItemDto consumable)
    {
        string checksum = _checksumService.CalculateChecksum(consumable);
        return new CreateConsumableDto
        {
            Checksum = checksum,
            Enabled = consumable.ActiveFlag == SmiteConstants.Yes,
            Description = !string.IsNullOrWhiteSpace(consumable.ItemDescription.Description) ? consumable.ItemDescription.Description : null,
            Name = consumable.DeviceName,
            ItemIconUrl = consumable.ItemIconUrl,
            Price = consumable.Price,
            SecondaryDescription = !string.IsNullOrWhiteSpace(consumable.ItemDescription.SecondaryDescription) ? consumable.ItemDescription.SecondaryDescription : null,
            ShortDescription = !string.IsNullOrWhiteSpace(consumable.ShortDesc) ? consumable.ShortDesc : null,
            SmiteId = consumable.ItemId
        };
    }
}
