using AutoMapper;
using Smitenight.Domain.Models.Clients.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.PlayerResponses;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class PlayerClientProfile : Profile
    {
        public PlayerClientProfile()
        {
            CreateMap<FriendsResponseDto, FriendsResponse>();
            CreateMap<GodRanksResponseDto, GodRanksResponse>();
            CreateMap<MatchHistoryResponseDto, MatchHistoryResponse>();
            CreateMap<PlayerAchievementsResponseDto, PlayerAchievementsResponse>();
            CreateMap<PlayerStatusResponseDto, PlayerStatusResponse>();
            CreateMap<QueueStatsResponseDto, QueueStatsResponse>();
            CreateMap<SearchPlayersResponseDto, SearchPlayersResponse>();
        }
    }
}
