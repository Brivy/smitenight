using AutoMapper;
using SmitenightApp.Domain.Clients.RetrievePlayerClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.RetrievePlayerResponses;

namespace SmitenightApp.Infrastructure.SmiteClient.Profiles
{
    public class RetrievePlayerClientProfile : Profile
    {
        public RetrievePlayerClientProfile()
        {
            CreateMap<PlayerIdResponseDto, PlayerIdResponse>();
            CreateMap<PlayerResponseDto, PlayerResponse>();

            #region Subobjects of PlayerResponseDto

            CreateMap<RankedConquestDto, RankedConquest>();
            CreateMap<RankedConquestControllerDto, RankedConquestController>();
            CreateMap<RankedDuelDto, RankedDuel>();
            CreateMap<RankedDuelControllerDto, RankedDuelController>();
            CreateMap<RankedJoustDto, RankedJoust>();
            CreateMap<RankedJoustControllerDto, RankedJoustController>();

            #endregion
        }
    }
}
