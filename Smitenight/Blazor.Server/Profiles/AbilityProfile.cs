using AutoMapper;
using Smitenight.Domain.Models.Contracts.Abilities;
using Smitenight.Domain.Models.Models.Abilities;

namespace Smitenight.Presentation.Blazor.Server.Profiles
{
    public class AbilityProfile : Profile
    {
        public AbilityProfile()
        {
            CreateMap<Ability, AbilityDto>();
            CreateMap<AbilityRank, AbilityRankDto>();
            CreateMap<AbilityTag, AbilityTagDto>();
        }
    }
}
