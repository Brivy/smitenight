using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.ItemResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.ItemResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
{
    public class ItemSmiteClientProfile : Profile
    {
        public ItemSmiteClientProfile()
        {
            CreateMap<GodRecommendedItemsResponseDto, GodRecommendedItemsResponse>();
            CreateMap<ItemsResponseDto, ItemsResponse>();

            #region Subobjects of ItemsResponse

            CreateMap<ItemDescriptionDto, ItemDescription>();
            CreateMap<MenuItemDto, MenuItem>();

            #endregion
        }
    }
}
