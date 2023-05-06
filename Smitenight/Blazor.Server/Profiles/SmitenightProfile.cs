using AutoMapper;
using Smitenight.Domain.Models.Contracts.Smitenights;
using Smitenight.Domain.Models.Models.Smitenights;

namespace Smitenight.Presentation.Blazor.Server.Profiles
{
    public class SmitenightProfile : Profile
    {
        public SmitenightProfile()
        {
            CreateMap<Domain.Models.Models.Smitenights.Smitenight, SmitenightDto>();
            CreateMap<SmitenightMatch, SmitenightMatchDto>();
        }
    }
}
