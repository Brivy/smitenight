using AutoMapper;
using Smitenight.Domain.Models.Clients.OtherClient;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.OtherClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class OtherClientProfile : Profile
    {
        public OtherClientProfile()
        {
            CreateMap<EsportProLeagueResponseDto, EsportProLeague>();
            CreateMap<MotdResponseDto, Motd>();
        }
    }
}
