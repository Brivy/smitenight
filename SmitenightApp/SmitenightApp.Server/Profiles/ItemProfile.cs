using AutoMapper;
using SmitenightApp.Domain.Contracts.Items;
using SmitenightApp.Domain.Models.Items;

namespace SmitenightApp.Server.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Active, ActiveDto>();
            CreateMap<ActivePurchase, ActivePurchaseDto>();
            CreateMap<Consumable, ConsumableDto>();
            CreateMap<ConsumableDescription, ConsumableDescriptionDto>();
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDescription, ItemDescriptionDto>();
            CreateMap<ItemPurchase, ItemPurchaseDto>();
        }
    }
}
