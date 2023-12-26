using Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.RetrievePlayerClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class RankedDetailsMapper : Mapper<RankedDetails, RankedDetailsDto>
{
    public override RankedDetailsDto Map(RankedDetails input)
    {
        return new RankedDetailsDto
        {
            PlayerId = input.PlayerId,
            Leaves = input.Leaves,
            Losses = input.Losses,
            Name = input.Name ?? string.Empty,
            Points = input.Points,
            PrevRank = input.PrevRank,
            Rank = input.Rank,
            RankStat = input.RankStat,
            RankStatJoust = input.RankStatJoust,
            RankStatConquest = input.RankStatConquest,
            RankVariance = input.RankVariance,
            Season = input.Season,
            Tier = input.Tier,
            Trend = input.Trend,
            Wins = input.Wins,
            RetMsg = input.RetMsg ?? string.Empty,
            Round = input.Round
        };
    }
}
