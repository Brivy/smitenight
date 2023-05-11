using AutoMapper;
using Smitenight.Domain.Models.Clients.OtherClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.OtherClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class OtherClientProfile : Profile
    {
        public OtherClientProfile()
        {
            CreateMap<EsportProLeague, EsportProLeagueDto>();
            CreateMap<Motd, MotdDto>();
        }
    }
}
