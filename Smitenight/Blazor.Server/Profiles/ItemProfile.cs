using AutoMapper;
using Smitenight.Domain.Models.Contracts.Items;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Presentation.Blazor.Server.Profiles
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
