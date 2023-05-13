using AutoMapper;
using Smitenight.Domain.Models.Contracts.Players;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Presentation.Blazor.Server.Profiles
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
