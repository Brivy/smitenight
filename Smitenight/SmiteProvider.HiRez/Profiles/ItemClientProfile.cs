using AutoMapper;
using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.ItemResponses;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class ItemClientProfile : Profile
    {
        public ItemClientProfile()
        {
            CreateMap<GodRecommendedItemsResponseDto, GodRecommendedItemsResponse>();
            CreateMap<ItemsResponseDto, ItemsResponse>();

            #region Subobjects of ItemResponse

            CreateMap<ItemDescriptionDto, ItemDescription>();
            CreateMap<MenuItemDto, MenuItem>();

            #endregion
        }
    }
}
