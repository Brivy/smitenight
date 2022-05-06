using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Infrastructure.SmiteClient.Contracts;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
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
