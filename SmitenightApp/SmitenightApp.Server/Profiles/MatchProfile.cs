using AutoMapper;
using SmitenightApp.Domain.Contracts.Matches;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Server.Profiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, MatchDto>();
            CreateMap<MatchDetail, MatchDetailDto>();
        }
    }
}
