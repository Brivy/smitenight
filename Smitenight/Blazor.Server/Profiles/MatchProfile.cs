using AutoMapper;
using Smitenight.Domain.Models.Contracts.Matches;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Presentation.Blazor.Server.Profiles
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
