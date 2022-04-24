namespace Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;

public record class GodRecommendedItemDto
{
    public string Category { get; init; } = null!;
    public string Item { get; init; } = null!;
    public string Role { get; init; } = null!;
    public int CategoryValueId { get; init; }
    public int GodId { get; init; }
    public string GodName { get; init; } = null!;
    public int IconId { get; init; }
    public int ItemId { get; init; }
    public string? RetMsg { get; init; }
    public int RoleValueId { get; init; }
}
