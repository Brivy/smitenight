using AutoMapper;
using Smitenight.Domain.Models.Clients.LeagueClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.LeagueClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class LeagueClientProfile : Profile
    {
        public LeagueClientProfile()
        {
            CreateMap<LeagueLeaderboard, LeagueLeaderboardDto>();
            CreateMap<LeagueSeason, LeagueSeasonDto>();
        }
    }
}
