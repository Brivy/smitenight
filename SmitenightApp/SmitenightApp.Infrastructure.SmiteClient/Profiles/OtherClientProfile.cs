using AutoMapper;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.OtherResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.OtherResponses;

namespace SmitenightApp.Infrastructure.SmiteClient.Profiles
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
