using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class QueueStatsMapper : Mapper<QueueStats, QueueStatsDto>
    {
        public override QueueStatsDto Map(QueueStats input)
        {
            return new QueueStatsDto
            {
                RetMsg = input.RetMsg,
                Assists = input.Assists,
                Deaths = input.Deaths,
                Kills = input.Kills,
                God = input.God ?? string.Empty,
                GodId = input.GodId,
                Losses = input.Losses,
                Matches = input.Matches,
                Minutes = input.Minutes,
                Queue = input.Queue ?? string.Empty,
                Wins = input.Wins,
                Gold = input.Gold,
                LastPlayed = input.LastPlayed ?? string.Empty,
                PlayerId = input.PlayerId ?? string.Empty,
            };
        }
    }
}
