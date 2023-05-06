namespace Smitenight.Domain.Models.Clients.OtherClient
{
    public record class EsportProLeagueResponse
    (
        int AwayTeamClanId,
        string? AwayTeamName,
        string? AwayTeamTagname,
        int HomeTeamClanId,
        string? HomeTeamName,
        string? HomeTeamTagname,
        string? MapInstanceId,
        string? MatchDate,
        string? MatchNumber,
        string? MatchStatus,
        string? MatchupId,
        string? Region,
        string? RetMsg,
        string? TournamentName,
        int WinningTeamClanId
    );
}
