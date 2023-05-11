using AutoMapper;
using Smitenight.Domain.Models.Clients.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.RetrievePlayerClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Profiles
{
    public class RetrievePlayerClientProfile : Profile
    {
        public RetrievePlayerClientProfile()
        {
            CreateMap<PlayerId, PlayerIdDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PlayerId));
            CreateMap<Player, PlayerDto>();

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
