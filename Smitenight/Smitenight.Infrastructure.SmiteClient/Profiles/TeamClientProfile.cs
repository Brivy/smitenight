using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.TeamResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.TeamResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
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
