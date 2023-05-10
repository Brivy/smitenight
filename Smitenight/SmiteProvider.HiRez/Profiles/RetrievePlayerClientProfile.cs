using AutoMapper;
using Smitenight.Domain.Models.Clients.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.RetrievePlayerClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class RetrievePlayerClientProfile : Profile
    {
        public RetrievePlayerClientProfile()
        {
            CreateMap<PlayerIdResponseDto, PlayerId>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PlayerId));
            CreateMap<PlayerResponseDto, Player>();

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
