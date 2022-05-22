using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.MatchInfoResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.MatchInfoResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
{
    public class MatchInfoClientProfile : Profile
    {
        public MatchInfoClientProfile()
        {
            CreateMap<DemoDetailsResponseDto, DemoDetailsResponse>();
            CreateMap<MatchDetailsResponseDto, MatchDetailsResponse>();
            CreateMap<MatchIdsByQueueResponseDto, MatchIdsByQueueResponse>();
            CreateMap<MatchPlayersDetailsResponseDto, MatchPlayersDetailsResponse>();
            CreateMap<TopMatchesResponseDto, TopMatchesResponse>();
        }
    }
}
