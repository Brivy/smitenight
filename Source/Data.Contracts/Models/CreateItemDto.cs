using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.Contracts.Models;

public record CreateItemDto
{
    public required int SmiteId { get; init; }
    public required string Checksum { get; init; }
    public required bool Enabled { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required bool Glyph { get; init; }
    public required ItemTier ItemTier { get; init; }
    public required int Price { get; init; }
    public required RestrictedRoles RestrictedRoles { get; init; }
    public string? SecondaryDescription { get; init; }
    public string? ShortDescription { get; init; }
    public required bool StartingItem { get; init; }
    public required string ItemIconUrl { get; init; }
    public IEnumerable<CreateItemDescriptionDto> ItemDescription { get; init; } = new List<CreateItemDescriptionDto>();
}
