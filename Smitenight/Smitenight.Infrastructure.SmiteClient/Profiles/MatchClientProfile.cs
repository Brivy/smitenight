using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.MatchResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
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
