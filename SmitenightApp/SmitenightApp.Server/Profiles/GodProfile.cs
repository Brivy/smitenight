using AutoMapper;
using SmitenightApp.Domain.Contracts.Gods;
using SmitenightApp.Domain.Models.Gods;

namespace SmitenightApp.Server.Profiles
{
    public class GodProfile : Profile
    {
        public GodProfile()
        {
            CreateMap<GodSkin, GodSkinDto>();
        }
    }
}
