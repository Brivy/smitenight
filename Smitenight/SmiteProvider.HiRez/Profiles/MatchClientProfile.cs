using AutoMapper;
using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class MatchClientProfile : Profile
    {
        public MatchClientProfile()
        {
            CreateMap<DemoDetails, DemoDetailsDto>();
            CreateMap<MatchDetails, MatchDetailsDto>();
            CreateMap<MatchIdsByQueue, MatchIdsByQueueDto>();
            CreateMap<MatchPlayersDetails, MatchPlayersDetailsDto>();
            CreateMap<TopMatch, TopMatchDto>();
        }
    }
}
