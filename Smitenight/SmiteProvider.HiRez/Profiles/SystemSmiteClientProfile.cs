using AutoMapper;
using Smitenight.Domain.Models.Clients.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class SystemSmiteClientProfile : Profile
    {
        public SystemSmiteClientProfile()
        {
            CreateMap<CreateSmiteSession, CreateSmiteSessionDto>();
            CreateMap<DataUsed, DataUsedDto>();
            CreateMap<HirezServerStatus, HirezServerStatusDto>();
            CreateMap<PatchInfo, PatchInfoDto>();
        }
    }
}
