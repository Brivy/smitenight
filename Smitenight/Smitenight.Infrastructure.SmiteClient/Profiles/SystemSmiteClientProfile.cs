using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.SystemResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.SystemResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
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
