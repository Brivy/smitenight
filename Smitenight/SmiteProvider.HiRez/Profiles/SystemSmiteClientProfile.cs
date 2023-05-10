using AutoMapper;
using Smitenight.Domain.Models.Clients.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.SystemClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class SystemSmiteClientProfile : Profile
    {
        public SystemSmiteClientProfile()
        {
            CreateMap<CreateSmiteSessionResponseDto, CreateSmiteSession>();
            CreateMap<DataUsedResponseDto, DataUsed>();
            CreateMap<HirezServerStatusResponseDto, HirezServerStatus>();
            CreateMap<PatchInfoResponseDto, PatchInfo>();
        }
    }
}
