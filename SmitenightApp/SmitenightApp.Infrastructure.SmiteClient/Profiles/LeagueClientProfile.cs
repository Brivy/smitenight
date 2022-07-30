using AutoMapper;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.LeagueResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.LeagueResponses;

namespace SmitenightApp.Infrastructure.SmiteClient.Profiles
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
