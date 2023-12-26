namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class GodRankDto
{
    public required int Assists { get; init; }
    public required int Deaths { get; init; }
    public required int Kills { get; init; }
    public required int Losses { get; init; }
    public required int MinionKills { get; init; }
    public required int Rank { get; init; }
    public required int Wins { get; init; }
    public required int Worshippers { get; init; }
    public required string God { get; init; }
    public required string GodId { get; init; }
    public required string PlayerId { get; init; }
    public string? RetMsg { get; init; }
}
