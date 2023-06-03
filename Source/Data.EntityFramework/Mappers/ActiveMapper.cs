using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class ActiveMapper : Mapper<CreateActiveDto, Active>
    {
        public override Active Map(CreateActiveDto input)
        {
            return new Active
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
                ItemTier = input.ItemTier,
                Latest = true // If we map it from a CreateDto, it's always the latest
            };
        }
    }
}
