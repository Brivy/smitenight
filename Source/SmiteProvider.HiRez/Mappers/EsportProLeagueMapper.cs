using Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.OtherClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class EsportProLeagueMapper : Mapper<EsportProLeague, EsportProLeagueDto>
    {
        public override EsportProLeagueDto Map(EsportProLeague input)
        {
            return new EsportProLeagueDto
            {
                AwayTeamClanId = input.AwayTeamClanId,
                AwayTeamName = input.AwayTeamName ?? string.Empty,
                AwayTeamTagname = input.AwayTeamTagname ?? string.Empty,
                HomeTeamClanId = input.HomeTeamClanId,
                HomeTeamName = input.HomeTeamName ?? string.Empty,
                HomeTeamTagname = input.HomeTeamTagname ?? string.Empty,
                MapInstanceId = input.MapInstanceId ?? string.Empty,
                MatchDate = input.MatchDate ?? string.Empty,
                MatchNumber = input.MatchNumber ?? string.Empty,
                MatchStatus = input.MatchStatus ?? string.Empty,
                MatchupId = input.MatchupId ?? string.Empty,
                Region = input.Region ?? string.Empty,
                RetMsg = input.RetMsg ?? string.Empty,
                TournamentName = input.TournamentName ?? string.Empty,
                WinningTeamClanId = input.WinningTeamClanId
            };
        }
    }
}
