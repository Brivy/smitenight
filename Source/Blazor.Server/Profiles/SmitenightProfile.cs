using AutoMapper;
using Smitenight.Domain.Models.Contracts.Smitenights;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Presentation.Blazor.Server.Profiles
{
    public class SmitenightProfile : Profile
    {
        public SmitenightProfile()
        {
            CreateMap<Persistence.Data.EntityFramework.Entities.Smitenight, SmitenightDto>();
            CreateMap<SmitenightMatch, SmitenightMatchDto>();
        }
    }
}
