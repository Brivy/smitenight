using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class ConsumableMapper : Mapper<CreateConsumableDto, Consumable>
    {
        public override Consumable Map(CreateConsumableDto input)
        {
            return new Consumable
            {
                SmiteId = input.SmiteId,
                Name = input.Name,
                Checksum = input.Checksum,
                Description = input.Description,
                ItemIconUrl = input.ItemIconUrl,
                Price = input.Price,
                Enabled = input.Enabled,
                SecondaryDescription = input.SecondaryDescription,
                ShortDescription = input.ShortDescription,
                Latest = true // If we map it from a CreateDto, it's always the latest
            };
        }
    }
}
