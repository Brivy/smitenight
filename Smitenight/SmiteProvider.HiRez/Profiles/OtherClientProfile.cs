using AutoMapper;
using Smitenight.Domain.Models.Clients.OtherClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.OtherResponses;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class OtherClientProfile : Profile
    {
        public OtherClientProfile()
        {
            CreateMap<EsportProLeagueResponseDto, EsportProLeagueResponse>();
            CreateMap<MotdResponseDto, MotdResponse>();
        }
    }
}
