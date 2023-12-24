namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class GodRankDto
{
    public int Assists { get; init; }
    public int Deaths { get; init; }
    public int Kills { get; init; }
    public int Losses { get; init; }
    public int MinionKills { get; init; }
    public int Rank { get; init; }
    public int Wins { get; init; }
    public int Worshippers { get; init; }
    public string God { get; init; } = null!;
    public string GodId { get; init; } = null!;
    public string PlayerId { get; init; } = null!;
    public string? RetMsg { get; init; }
}
