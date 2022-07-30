using AutoMapper;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.PlayerResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.PlayerResponses;

namespace SmitenightApp.Infrastructure.SmiteClient.Profiles
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
