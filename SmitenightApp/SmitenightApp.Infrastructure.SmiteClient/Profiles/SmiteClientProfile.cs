using AutoMapper;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts;

namespace SmitenightApp.Infrastructure.SmiteClient.Profiles
{
    public class SmiteClientProfile : Profile
    {
        public SmiteClientProfile()
        {
            CreateMap<SmiteClientResponseDto, SmiteClientResponse>();
            CreateMap(typeof(SmiteClientResponseDto<>), typeof(SmiteClientResponse<>));
            CreateMap(typeof(SmiteClientListResponseDto<>), typeof(SmiteClientListResponse<>));
        }
    }
}
