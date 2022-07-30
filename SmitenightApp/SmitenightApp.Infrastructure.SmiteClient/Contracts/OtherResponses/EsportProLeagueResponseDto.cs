using System.Text.Json.Serialization;

namespace SmitenightApp.Infrastructure.SmiteClient.Contracts.OtherResponses
{
    public record class EsportProLeagueResponseDto
    {
        [JsonPropertyName("away_team_clan_id")] public int AwayTeamClanId { get; init; }
        [JsonPropertyName("away_team_name")] public string? AwayTeamName { get; init; }
        [JsonPropertyName("away_team_tagname")] public string? AwayTeamTagname { get; init; }
        [JsonPropertyName("home_team_clan_id")] public int HomeTeamClanId { get; init; }
        [JsonPropertyName("home_team_name")] public string? HomeTeamName { get; init; }
        [JsonPropertyName("home_team_tagname")] public string? HomeTeamTagname { get; init; }
        [JsonPropertyName("map_instance_id")] public string? MapInstanceId { get; init; }
        [JsonPropertyName("match_date")] public string? MatchDate { get; init; }
        [JsonPropertyName("match_number")] public string? MatchNumber { get; init; }
        [JsonPropertyName("match_status")] public string? MatchStatus { get; init; }
        [JsonPropertyName("matchup_id")] public string? MatchupId { get; init; }
        [JsonPropertyName("region")] public string? Region { get; init; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; init; }
        [JsonPropertyName("tournament_name")] public string? TournamentName { get; init; }
        [JsonPropertyName("winning_team_clan_id")] public int WinningTeamClanId { get; init; }
    }
}
