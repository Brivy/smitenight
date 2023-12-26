using Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class DemoDetailsMapper : Mapper<DemoDetails, DemoDetailsDto>
{
    public override DemoDetailsDto Map(DemoDetails input)
    {
        return new DemoDetailsDto
        {
            BanId1 = input.BanId1,
            BanId2 = input.BanId2,
            BanId3 = input.BanId3,
            BanId4 = input.BanId4,
            EntryDatetime = input.EntryDatetime ?? string.Empty,
            Match = input.Match,
            MatchTime = input.MatchTime,
            OfflineSpectators = input.OfflineSpectators,
            Queue = input.Queue ?? string.Empty,
            RealtimeSpectators = input.RealtimeSpectators,
            RecordingEnded = input.RecordingEnded ?? string.Empty,
            RecordingStarted = input.RecordingStarted ?? string.Empty,
            Team1AvgLevel = input.Team1AvgLevel,
            Team1Gold = input.Team1Gold,
            Team1Kills = input.Team1Kills,
            Team1Score = input.Team1Score,
            Team2AvgLevel = input.Team2AvgLevel,
            Team2Gold = input.Team2Gold,
            Team2Kills = input.Team2Kills,
            Team2Score = input.Team2Score,
            WinningTeam = input.WinningTeam,
            RetMsg = input.RetMsg ?? string.Empty
        };
    }
}
