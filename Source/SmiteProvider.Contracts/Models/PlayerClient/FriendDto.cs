namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class FriendDto
{
    public string AccountId { get; init; } = null!;
    public string AvatarUrl { get; init; } = null!;
    public string FriendFlags { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string PlayerId { get; init; } = null!;
    public string PortalId { get; init; } = null!;
    public string? RetMsg { get; init; }
    public string Status { get; init; } = null!;
}
