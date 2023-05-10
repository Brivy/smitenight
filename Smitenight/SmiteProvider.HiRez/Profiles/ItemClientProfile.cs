using AutoMapper;
using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.ItemClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class ItemClientProfile : Profile
    {
        public ItemClientProfile()
        {
            CreateMap<GodRecommendedItemsResponseDto, GodRecommendedItem>();
            CreateMap<ItemsResponseDto, Item>();

            #region Subobjects of ItemResponse

            CreateMap<ItemDescriptionDto, ItemDescription>();
            CreateMap<MenuItemDto, MenuItem>();

            #endregion
        }
    }
}
