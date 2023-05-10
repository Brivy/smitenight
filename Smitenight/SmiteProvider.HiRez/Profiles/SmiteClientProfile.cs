using AutoMapper;
using Smitenight.Providers.SmiteProvider.Contracts.Models;
using Smitenight.Providers.SmiteProvider.HiRez.Responses;

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
