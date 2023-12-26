namespace Smitenight.Persistence.Data.Contracts.Models;

public record CreateConsumableDto
{
    public required int SmiteId { get; init; }
    public required string Checksum { get; init; }
    public required bool Enabled { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required int Price { get; init; }
    public string? SecondaryDescription { get; init; }
    public string? ShortDescription { get; init; }
    public required string ItemIconUrl { get; init; }
}
