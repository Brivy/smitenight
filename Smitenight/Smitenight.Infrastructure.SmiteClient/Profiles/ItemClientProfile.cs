using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.ItemResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.ItemResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
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
