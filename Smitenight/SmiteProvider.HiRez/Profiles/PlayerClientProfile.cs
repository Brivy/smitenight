using AutoMapper;
using Smitenight.Domain.Models.Clients.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class PlayerClientProfile : Profile
    {
        public PlayerClientProfile()
        {
            CreateMap<Friend, FriendDto>();
            CreateMap<GodRank, GodRankDto>();
            CreateMap<MatchHistory, MatchHistoryDto>();
            CreateMap<PlayerAchievement, PlayerAchievementDto>();
            CreateMap<PlayerStatus, PlayerStatusDto>();
            CreateMap<QueueStats, QueueStatsDto>();
            CreateMap<SearchPlayers, SearchPlayerDto>();
        }
    }
}
