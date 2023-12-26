namespace Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient;

public record class EsportProLeagueDto
{
    public required int AwayTeamClanId { get; init; }
    public required string AwayTeamName { get; init; }
    public required string AwayTeamTagname { get; init; }
    public required int HomeTeamClanId { get; init; }
    public required string HomeTeamName { get; init; }
    public required string HomeTeamTagname { get; init; }
    public required string MapInstanceId { get; init; }
    public required string MatchDate { get; init; }
    public required string MatchNumber { get; init; }
    public required string MatchStatus { get; init; }
    public required string MatchupId { get; init; }
    public required string Region { get; init; }
    public string? RetMsg { get; init; }
    public required string TournamentName { get; init; }
    public required int WinningTeamClanId { get; init; }
}
