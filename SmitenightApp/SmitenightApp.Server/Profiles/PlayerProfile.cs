using AutoMapper;
using SmitenightApp.Domain.Contracts.Players;
using SmitenightApp.Domain.Models.Players;

namespace SmitenightApp.Server.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerNameAttempt, PlayerNameAttemptDto>();
        }
    }
}
