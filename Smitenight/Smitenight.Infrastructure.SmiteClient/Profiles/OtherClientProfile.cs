using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.OtherResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.OtherResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
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
