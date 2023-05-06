using AutoMapper;
using Smitenight.Domain.Models.Clients.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.RetrievePlayerResponses;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
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
