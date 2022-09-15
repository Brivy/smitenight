using AutoMapper;
using SmitenightApp.Domain.Clients.SystemClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.SystemResponses;

namespace SmitenightApp.Infrastructure.SmiteClient.Profiles
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
