using AutoMapper;
using Smitenight.Domain.Models.Clients.LeagueClient;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.LeagueClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class LeagueClientProfile : Profile
    {
        public LeagueClientProfile()
        {
            CreateMap<LeagueLeaderboardResponseDto, LeagueLeaderboard>();
            CreateMap<LeagueSeasonsResponseDto, LeagueSeason>();
        }
    }
}
