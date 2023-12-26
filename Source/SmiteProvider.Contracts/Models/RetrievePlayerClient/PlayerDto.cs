namespace Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;

public record class PlayerDto
{
    public required int ActivePlayerId { get; init; }
    public required string AvatarUrl { get; init; }
    public required string CreatedDatetime { get; init; }
    public required int HoursPlayed { get; init; }
    public required int Id { get; init; }
    public required string LastLoginDatetime { get; init; }
    public required int Leaves { get; init; }
    public required int Level { get; init; }
    public required int Losses { get; init; }
    public required int MasteryLevel { get; init; }
    public required string MergedPlayers { get; init; }
    public required int MinutesPlayed { get; init; }
    public required string Name { get; init; }
    public required string PersonalStatusMessage { get; init; }
    public required string Platform { get; init; }
    public required float RankStatConquest { get; init; }
    public required float RankStatConquestController { get; init; }
    public required float RankStatDuel { get; init; }
    public required float RankStatDuelController { get; init; }
    public required float RankStatJoust { get; init; }
    public required float RankStatJoustController { get; init; }
    public required RankedDetailsDto RankedConquest { get; init; }
    public required RankedDetailsDto RankedConquestController { get; init; }
    public required RankedDetailsDto RankedDuel { get; init; }
    public required RankedDetailsDto RankedDuelController { get; init; }
    public required RankedDetailsDto RankedJoust { get; init; }
    public required RankedDetailsDto RankedJoustController { get; init; }
    public required string Region { get; init; }
    public required int TeamId { get; init; }
    public required string TeamName { get; init; }
    public required int TierConquest { get; init; }
    public required int TierDuel { get; init; }
    public required int TierJoust { get; init; }
    public required int TotalAchievements { get; init; }
    public required int TotalWorshippers { get; init; }
    public required int Wins { get; init; }
    public required string HzGamerTag { get; init; }
    public required string HzPlayerName { get; init; }
    public string? RetMsg { get; init; }
}
