using Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.LeagueClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class LeagueLeaderboardMapper : Mapper<LeagueLeaderboard, LeagueLeaderboardDto>
{
    public override LeagueLeaderboardDto Map(LeagueLeaderboard input)
    {
        return new LeagueLeaderboardDto
        {
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
            Round = input.Round,
            Season = input.Season,
            Tier = input.Tier,
            Trend = input.Trend,
            Wins = input.Wins,
            PlayerId = input.PlayerId ?? string.Empty,
            RetMsg = input.RetMsg ?? string.Empty
        };
    }
}
