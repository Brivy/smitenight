using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Contracts;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class ItemMapper : Mapper<CreateItemDto, Item>
    {
        private readonly IMapper<CreateItemDescriptionDto, ItemDescription> _itemDescriptionMapper;

        public ItemMapper(IMapper<CreateItemDescriptionDto, ItemDescription> itemDescriptionMapper)
        {
            _itemDescriptionMapper = itemDescriptionMapper;
        }

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
                StartingItem = input.StartingItem,
                ItemDescriptions = input.ItemDescription.Select(_itemDescriptionMapper.Map).ToList(),
                Latest = true // If we map it from a CreateDto, it's always the latest
            };
        }
    }
}
