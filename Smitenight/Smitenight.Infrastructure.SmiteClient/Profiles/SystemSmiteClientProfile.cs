using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.SystemResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.SystemResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
{
    public class SystemSmiteClientProfile : Profile
    {
        public SystemSmiteClientProfile()
        {
            CreateMap<CreateSmiteSessionResponse, CreateSmiteSessionResponseModel>()
                .ForCtorParam(nameof(CreateSmiteSessionResponseModel.SessionId), opt => opt.MapFrom(src => src.session_id))
                .ForCtorParam(nameof(CreateSmiteSessionResponseModel.RetMsg), opt => opt.MapFrom(src => src.ret_msg))
                .ForCtorParam(nameof(CreateSmiteSessionResponseModel.Timestamp), opt => opt.MapFrom(src => src.timestamp));
        }
    }
}
