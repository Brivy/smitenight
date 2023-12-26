using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class GodLeaderboardMapper : Mapper<GodLeaderboard, GodLeaderboardDto>
{
    public override GodLeaderboardDto Map(GodLeaderboard input)
    {
        return new GodLeaderboardDto
        {
            GodId = input.GodId ?? string.Empty,
            Losses = input.Losses ?? string.Empty,
            PlayerId = input.PlayerId ?? string.Empty,
            PlayerName = input.PlayerName ?? string.Empty,
            PlayerRanking = input.PlayerRanking ?? string.Empty,
            Rank = input.Rank ?? string.Empty,
            RetMsg = input.RetMsg ?? string.Empty,
            Wins = input.Wins ?? string.Empty
        };
    }
}
