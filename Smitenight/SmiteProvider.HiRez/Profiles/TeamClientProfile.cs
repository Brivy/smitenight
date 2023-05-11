using AutoMapper;
using Smitenight.Domain.Models.Clients.TeamClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.TeamClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class TeamClientProfile : Profile
    {
        public TeamClientProfile()
        {
            CreateMap<TeamDetails, TeamDetailsDto>();
            CreateMap<TeamPlayers, TeamPlayerDto>();
            CreateMap<SearchTeams, SearchTeamsDto>();
        }
    }
}
