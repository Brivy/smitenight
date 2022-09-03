using AutoMapper;
using SmitenightApp.Domain.Contracts.Abilities;
using SmitenightApp.Domain.Models.Abilities;

namespace SmitenightApp.Server.Profiles
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
