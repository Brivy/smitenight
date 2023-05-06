using AutoMapper;
using Smitenight.Domain.Models.Clients.LeagueClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.LeagueResponses;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class LeagueClientProfile : Profile
    {
        public LeagueClientProfile()
        {
            CreateMap<LeagueLeaderboardResponseDto, LeagueLeaderboardResponse>();
            CreateMap<LeagueSeasonsResponseDto, LeagueSeasonsResponse>();
        }
    }
}
