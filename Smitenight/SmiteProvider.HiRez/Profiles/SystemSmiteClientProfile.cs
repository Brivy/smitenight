using AutoMapper;
using Smitenight.Domain.Models.Clients.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.SystemResponses;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class SystemSmiteClientProfile : Profile
    {
        public SystemSmiteClientProfile()
        {
            CreateMap<CreateSmiteSessionResponseDto, CreateSmiteSessionResponse>();
            CreateMap<DataUsedResponseDto, DataUsedResponse>();
            CreateMap<HirezServerStatusResponseDto, HirezServerStatusResponse>();
            CreateMap<PatchInfoResponseDto, PatchInfoResponse>();
        }
    }
}
