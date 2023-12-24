using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.ItemClient;
using Smitenight.Utilities.Mapper.Contracts.Contracts;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

public class ItemMapper(IMapper<ItemDescription, ItemDescriptionDto> itemDescriptionMapper) : Mapper<Item, ItemDto>
{
    private readonly IMapper<ItemDescription, ItemDescriptionDto> _itemDescriptionMapper = itemDescriptionMapper;

    public override ItemDto Map(Item input)
    {
        return new ItemDto
        {
            ActiveFlag = input.ActiveFlag ?? string.Empty,
            ChildItemId = input.ChildItemId,
            DeviceName = input.DeviceName ?? string.Empty,
            IconId = input.IconId,
            ItemDescription = _itemDescriptionMapper.Map(input.ItemDescription),
            ItemId = input.ItemId,
            ItemTier = input.ItemTier,
            Price = input.Price,
            RestrictedRoles = input.RestrictedRoles ?? string.Empty,
            RootItemId = input.RootItemId,
            ShortDesc = input.ShortDesc ?? string.Empty,
            StartingItem = input.StartingItem,
            Type = input.Type ?? string.Empty,
            ItemIconUrl = input.ItemIconUrl ?? string.Empty,
            RetMsg = input.RetMsg ?? string.Empty,
            Glyph = input.Glyph ?? string.Empty
        };
    }
}
