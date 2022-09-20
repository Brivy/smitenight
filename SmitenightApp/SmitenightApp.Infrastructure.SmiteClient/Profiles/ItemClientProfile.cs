using AutoMapper;
using SmitenightApp.Domain.Clients.ItemClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.ItemResponses;

namespace SmitenightApp.Infrastructure.SmiteClient.Profiles
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
