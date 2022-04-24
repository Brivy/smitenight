using Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

public class MatchPlayerDetailsMapper : Mapper<MatchPlayerDetails, MatchPlayerDetailsDto>
{
    public override MatchPlayerDetailsDto Map(MatchPlayerDetails input)
    {
        return new MatchPlayerDetailsDto
        {
            AccountGodsPlayed = input.AccountGodsPlayed,
            AccountLevel = input.AccountLevel,
            GodId = input.GodId,
            GodLevel = input.GodLevel,
            GodName = input.GodName ?? string.Empty,
            MasteryLevel = input.MasteryLevel,
            PlayerCreated = input.PlayerCreated ?? string.Empty,
            PlayerId = input.PlayerId ?? string.Empty,
            PlayerName = input.PlayerName ?? string.Empty,
            Queue = input.Queue ?? string.Empty,
            MapGame = input.MapGame ?? string.Empty,
            SkinId = input.SkinId,
            Match = input.Match,
            PlayerRegion = input.PlayerRegion ?? string.Empty,
            TaskForce = input.TaskForce,
            RankStat = input.RankStat,
            Tier = input.Tier,
            RetMsg = input.RetMsg,
            TierLosses = input.TierLosses,
            TierWins = input.TierWins,
            TierPoints = input.TierPoints
        };
    }
}
