using AutoMapper;
using Smitenight.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.RetrievePlayerResponses;

namespace Smitenight.Infrastructure.SmiteClient.Profiles
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
