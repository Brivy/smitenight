using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.GodResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.GodResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
{
    public class GodClientProfile : Profile
    {
        public GodClientProfile()
        {
            CreateMap<GodAltAbilitiesResponseDto, GodAltAbilitiesResponse>();
            CreateMap<GodLeaderbordResponseDto, GodLeaderbordResponse>();
            CreateMap<GodsResponseDto, GodsResponse>();
            CreateMap<GodSkinsResponseDto, GodSkinsResponse>();

            #region Subobjects of GodsResponse

            CreateMap<AbilityDetails1Dto, AbilityDetails1>();
            CreateMap<AbilityDetails2Dto, AbilityDetails2>();
            CreateMap<AbilityDetails3Dto, AbilityDetails3>();
            CreateMap<AbilityDetails4Dto, AbilityDetails4>();
            CreateMap<AbilityDetails5Dto, AbilityDetails5>();

            CreateMap<AbilityDescription1Dto, AbilityDescription1>();
            CreateMap<AbilityDescription2Dto, AbilityDescription2>();
            CreateMap<AbilityDescription3Dto, AbilityDescription3>();
            CreateMap<AbilityDescription4Dto, AbilityDescription4>();
            CreateMap<AbilityDescription5Dto, AbilityDescription5>();

            CreateMap<BasicAttackDto, BasicAttack>();

            CreateMap<DescriptionDto, Description>();
            CreateMap<Description1Dto, Description1>();
            CreateMap<Description2Dto, Description2>();
            CreateMap<Description3Dto, Description3>();
            CreateMap<Description4Dto, Description4>();

            CreateMap<ItemDescriptionDto, ItemDescription>();
            CreateMap<ItemDescription1Dto, ItemDescription1>();
            CreateMap<ItemDescription2Dto, ItemDescription2>();
            CreateMap<ItemDescription3Dto, ItemDescription3>();
            CreateMap<ItemDescription4Dto, ItemDescription4>();
            CreateMap<ItemDescription5Dto, ItemDescription5>();
            CreateMap<ItemDescription6Dto, ItemDescription6>();
            CreateMap<ItemDescription7Dto, ItemDescription7>();
            CreateMap<ItemDescription8Dto, ItemDescription8>();
            CreateMap<ItemDescription9Dto, ItemDescription9>();
            CreateMap<ItemDescription10Dto, ItemDescription10>();

            CreateMap<MenuItemDto, MenuItem>();
            CreateMap<MenuItem1Dto, MenuItem1>();
            CreateMap<MenuItem2Dto, MenuItem2>();
            CreateMap<MenuItem3Dto, MenuItem3>();
            CreateMap<MenuItem4Dto, MenuItem4>();
            CreateMap<MenuItem5Dto, MenuItem5>();
            CreateMap<MenuItem6Dto, MenuItem6>();
            CreateMap<MenuItem7Dto, MenuItem7>();
            CreateMap<MenuItem8Dto, MenuItem8>();
            CreateMap<MenuItem9Dto, MenuItem9>();
            CreateMap<MenuItem10Dto, MenuItem10>();

            CreateMap<RankItemDto, RankItem>();
            CreateMap<RankItem1Dto, RankItem1>();
            CreateMap<RankItem2Dto, RankItem2>();
            CreateMap<RankItem3Dto, RankItem3>();
            CreateMap<RankItem4Dto, RankItem4>();
            CreateMap<RankItem5Dto, RankItem5>();
            CreateMap<RankItem6Dto, RankItem6>();
            CreateMap<RankItem7Dto, RankItem7>();
            CreateMap<RankItem8Dto, RankItem8>();
            CreateMap<RankItem9Dto, RankItem9>();

            #endregion
        }
    }
}
