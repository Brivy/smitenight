using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.LeagueResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.LeagueResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
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
