using AutoMapper;
using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.MatchClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class MatchClientProfile : Profile
    {
        public MatchClientProfile()
        {
            CreateMap<DemoDetailsResponseDto, DemoDetails>();
            CreateMap<MatchDetailsResponseDto, MatchDetails>();
            CreateMap<MatchIdsByQueueResponseDto, MatchIdsByQueue>();
            CreateMap<MatchPlayersDetailsResponseDto, MatchPlayersDetails>();
            CreateMap<TopMatchesResponseDto, TopMatch>();
        }
    }
}
