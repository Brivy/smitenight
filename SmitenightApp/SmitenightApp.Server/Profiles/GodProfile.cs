using AutoMapper;
using SmitenightApp.Domain.Contracts.Gods;
using SmitenightApp.Domain.Models.Gods;

namespace SmitenightApp.Server.Profiles
{
    public class GodProfile : Profile
    {
        public GodProfile()
        {
            CreateMap<BasicAttackDescription, BasicAttackDescriptionDto>();
            CreateMap<God, GodDto>();
            CreateMap<GodBan, GodBanDto>();
            CreateMap<GodSkin, GodSkinDto>();
        }
    }
}
