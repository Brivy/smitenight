using AutoMapper;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.MatchResponses;

namespace SmitenightApp.Infrastructure.SmiteClient.Profiles
{
    public class MatchClientProfile : Profile
    {
        public MatchClientProfile()
        {
            CreateMap<DemoDetailsResponseDto, DemoDetailsResponse>();
            CreateMap<MatchDetailsResponseDto, MatchDetailsResponse>();
            CreateMap<MatchIdsByQueueResponseDto, MatchIdsByQueueResponse>();
            CreateMap<MatchPlayersDetailsResponseDto, MatchPlayersDetailsResponse>();
            CreateMap<TopMatchesResponseDto, TopMatchesResponse>();
        }
    }
}
