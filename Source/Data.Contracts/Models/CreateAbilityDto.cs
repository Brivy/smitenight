using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.Contracts.Models;

public record CreateAbilityDto
{
    public required int SmiteId { get; init; }
    public required string Checksum { get; init; }
    public string? Cooldown { get; init; }
    public string? Cost { get; init; }
    public required string Description { get; init; }
    public required string Summary { get; init; }
    public required string Url { get; init; }
    public required AbilityType AbilityType { get; init; }
    public IEnumerable<CreateAbilityRankDto> AbilityRanks { get; init; } = new List<CreateAbilityRankDto>();
    public IEnumerable<CreateAbilityTagDto> AbilityTags { get; init; } = new List<CreateAbilityTagDto>();
}
