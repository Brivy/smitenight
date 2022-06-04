using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.PlayerResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.PlayerResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
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
