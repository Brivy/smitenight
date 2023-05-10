using AutoMapper;
using Smitenight.Domain.Models.Clients.TeamClient;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.TeamClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class TeamClientProfile : Profile
    {
        public TeamClientProfile()
        {
            CreateMap<TeamDetailsResponseDto, TeamDetails>();
            CreateMap<TeamPlayersResponseDto, TeamPlayer>();
            CreateMap<SearchTeamsResponseDto, SearchTeams>();
        }
    }
}
