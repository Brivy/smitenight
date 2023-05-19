using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class GodRankMapper : Mapper<GodRank, GodRankDto>
    {
        public override GodRankDto Map(GodRank input)
        {
            return new GodRankDto
            {
                Assists = input.Assists,
                Deaths = input.Deaths,
                Kills = input.Kills,
                Losses = input.Losses,
                MinionKills = input.MinionKills,
                Rank = input.Rank,
                Wins = input.Wins,
                Worshippers = input.Worshippers,
                God = input.God ?? string.Empty,
                GodId = input.GodId ?? string.Empty,
                PlayerId = input.PlayerId ?? string.Empty,
                RetMsg = input.RetMsg ?? string.Empty
            };
        }
    }
}
