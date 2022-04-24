namespace Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient;

public record class EsportProLeagueDto
{
    public int AwayTeamClanId { get; init; }
    public string AwayTeamName { get; init; } = null!;
    public string AwayTeamTagname { get; init; } = null!;
    public int HomeTeamClanId { get; init; }
    public string HomeTeamName { get; init; } = null!;
    public string HomeTeamTagname { get; init; } = null!;
    public string MapInstanceId { get; init; } = null!;
    public string MatchDate { get; init; } = null!;
    public string MatchNumber { get; init; } = null!;
    public string MatchStatus { get; init; } = null!;
    public string MatchupId { get; init; } = null!;
    public string Region { get; init; } = null!;
    public string? RetMsg { get; init; }
    public string TournamentName { get; init; } = null!;
    public int WinningTeamClanId { get; init; }
}
