using AutoMapper;
using Smitenight.Domain.Models.Clients.TeamClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.TeamResponses;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class TeamClientProfile : Profile
    {
        public TeamClientProfile()
        {
            CreateMap<TeamDetailsResponseDto, TeamDetailsResponse>();
            CreateMap<TeamPlayersResponseDto, TeamPlayersResponse>();
            CreateMap<SearchTeamsResponseDto, SearchTeamsResponse>();
        }
    }
}
