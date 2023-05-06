using AutoMapper;
using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.MatchResponses;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
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
