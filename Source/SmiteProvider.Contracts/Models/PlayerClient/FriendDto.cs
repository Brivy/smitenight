namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class FriendDto
{
    public required string AccountId { get; init; }
    public required string AvatarUrl { get; init; }
    public required string FriendFlags { get; init; }
    public required string Name { get; init; }
    public required string PlayerId { get; init; }
    public required string PortalId { get; init; }
    public string? RetMsg { get; init; }
    public required string Status { get; init; }
}
