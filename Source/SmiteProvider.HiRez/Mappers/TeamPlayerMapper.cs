using Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.TeamClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class TeamPlayerMapper : Mapper<TeamPlayer, TeamPlayerDto>
    {
        public override TeamPlayerDto Map(TeamPlayer input)
        {
            return new TeamPlayerDto
            {
                RetMsg = input.RetMsg,
                AccountLevel = input.AccountLevel,
                JoinedDatetime = input.JoinedDatetime ?? string.Empty,
                LastLoginDatetime = input.LastLoginDatetime ?? string.Empty,
                Name = input.Name ?? string.Empty,
                PlayerId = input.PlayerId ?? string.Empty
            };
        }
    }
}
