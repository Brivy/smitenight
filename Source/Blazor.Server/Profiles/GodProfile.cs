using AutoMapper;
using Smitenight.Domain.Models.Contracts.Gods;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Presentation.Blazor.Server.Profiles
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
