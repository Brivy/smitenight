using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.ItemClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class ItemMapper : Mapper<Item, ItemDto>
    {
        //private readonly IMapperService _mapperService;

        //public ItemMapper(IMapperService mapperService)
        //{
        //    _mapperService = mapperService;
        //}

        public override ItemDto Map(Item input)
        {
            return new ItemDto
            {
                ActiveFlag = input.ActiveFlag ?? string.Empty,
                ChildItemId = input.ChildItemId,
                DeviceName = input.DeviceName ?? string.Empty,
                IconId = input.IconId,
                //ItemDescription = _mapperService.Map<ItemDescription, ItemDescriptionDto>(input.ItemDescription),
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
}
