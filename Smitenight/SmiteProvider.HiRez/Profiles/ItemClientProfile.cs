using AutoMapper;
using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.ItemClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class ItemClientProfile : Profile
    {
        public ItemClientProfile()
        {
            CreateMap<GodRecommendedItem, GodRecommendedItemDto>();
            CreateMap<Item, ItemDto>();

            #region Subobjects of ItemResponse

            CreateMap<ItemDescriptionDto, ItemDescription>();
            CreateMap<MenuItemDto, MenuItem>();

            #endregion
        }
    }
}
