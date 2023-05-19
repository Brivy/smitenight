using Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class TopMatchMapper : Mapper<TopMatch, TopMatchDto>
    {
        public override TopMatchDto Map(TopMatch input)
        {
            return new TopMatchDto
            {
                RetMsg = input.RetMsg,
                Match = input.Match,
                Ban1 = input.Ban1 ?? string.Empty,
                Ban1Id = input.Ban1Id,
                Ban2 = input.Ban2 ?? string.Empty,
                Ban2Id = input.Ban2Id,
                EntryDatetime = input.EntryDatetime ?? string.Empty,
                LiveSpectators = input.LiveSpectators,
                MatchTime = input.MatchTime,
                OfflineSpectators = input.OfflineSpectators,
                Queue = input.Queue ?? string.Empty,
                RecordingFinished = input.RecordingFinished ?? string.Empty,
                RecordingStarted = input.RecordingStarted ?? string.Empty,
                Team1AvgLevel = input.Team1AvgLevel,
                Team1Gold = input.Team1Gold,
                Team1Kills = input.Team1Kills,
                Team1Score = input.Team1Score,
                Team2AvgLevel = input.Team2AvgLevel,
                Team2Gold = input.Team2Gold,
                Team2Kills = input.Team2Kills,
                Team2Score = input.Team2Score,
                WinningTeam = input.WinningTeam
            };
        }
    }
}
