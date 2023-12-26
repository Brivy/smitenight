namespace Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;

public record class GodRecommendedItemDto
{
    public required string Category { get; init; }
    public required string Item { get; init; }
    public required string Role { get; init; }
    public required int CategoryValueId { get; init; }
    public required int GodId { get; init; }
    public required string GodName { get; init; }
    public required int IconId { get; init; }
    public required int ItemId { get; init; }
    public string? RetMsg { get; init; }
    public required int RoleValueId { get; init; }
}
