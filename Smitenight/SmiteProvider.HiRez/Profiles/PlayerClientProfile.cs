using AutoMapper;
using Smitenight.Domain.Models.Clients.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.PlayerClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class PlayerClientProfile : Profile
    {
        public PlayerClientProfile()
        {
            CreateMap<FriendsResponseDto, Friend>();
            CreateMap<GodRanksResponseDto, GodRank>();
            CreateMap<MatchHistoryResponseDto, MatchHistory>();
            CreateMap<PlayerAchievementsResponseDto, PlayerAchievement>();
            CreateMap<PlayerStatusResponseDto, PlayerStatus>();
            CreateMap<QueueStatsResponseDto, QueueStats>();
            CreateMap<SearchPlayersResponseDto, SearchPlayer>();
        }
    }
}
