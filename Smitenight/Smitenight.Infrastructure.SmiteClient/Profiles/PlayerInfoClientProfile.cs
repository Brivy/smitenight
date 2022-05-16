using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.PlayerInfoResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.PlayerInfoResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
{
    public class PlayerInfoClientProfile : Profile
    {
        public PlayerInfoClientProfile()
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
