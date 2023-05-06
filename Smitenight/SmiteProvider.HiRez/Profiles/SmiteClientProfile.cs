using AutoMapper;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
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
