using AutoMapper;
using SmitenightApp.Domain.Contracts.Smitenights;
using SmitenightApp.Domain.Models.Smitenights;

namespace SmitenightApp.Server.Profiles
{
    public class SmitenightProfile : Profile
    {
        public SmitenightProfile()
        {
            CreateMap<Smitenight, SmitenightDto>();
        }
    }
}
