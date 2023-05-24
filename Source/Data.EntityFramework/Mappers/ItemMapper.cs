using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class ItemMapper : Mapper<CreateItemDto, Item>
    {
        public override Item Map(CreateItemDto input)
        {
            return new Item
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
                Glyph = input.Glyph,
                RestrictedRoles = input.RestrictedRoles,
                StartingItem = input.StartingItem
            };
        }
    }
}
