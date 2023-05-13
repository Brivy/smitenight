using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateConsumableMapper : Mapper<ItemDto, CreateConsumableDto>
    {
        public override CreateConsumableDto Map(ItemDto consumable)
        {
            return new CreateConsumableDto
            {
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
}
