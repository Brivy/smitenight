using AutoMapper;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.TeamResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.TeamResponses;

namespace SmitenightApp.Infrastructure.SmiteClient.Profiles
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
