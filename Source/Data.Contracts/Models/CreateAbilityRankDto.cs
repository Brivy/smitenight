namespace Smitenight.Persistence.Data.Contracts.Models;

public record CreateAbilityRankDto
{
    public string Description { get; set; } = null!;
    public string Value { get; set; } = null!;
}
