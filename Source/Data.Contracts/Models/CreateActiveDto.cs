using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.Contracts.Models;

public record CreateActiveDto
{
    public required int SmiteId { get; init; }
    public required string Checksum { get; init; }
    public bool Enabled { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public ItemTier ItemTier { get; init; }
    public int Price { get; init; }
    public required string SecondaryDescription { get; init; }
    public required string ShortDescription { get; init; }
    public required string ItemIconUrl { get; init; }
}
