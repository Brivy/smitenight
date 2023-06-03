using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class PlayerStatusMapper : Mapper<PlayerStatus, PlayerStatusDto>
    {
        public override PlayerStatusDto Map(PlayerStatus input)
        {
            return new PlayerStatusDto
            {
                Match = input.Match,
                PersonalStatusMessage = input.PersonalStatusMessage ?? string.Empty,
                MatchQueueId = input.MatchQueueId,
                RetMsg = input.RetMsg,
                Status = input.Status,
                StatusString = input.StatusString ?? string.Empty
            };
        }
    }
}
