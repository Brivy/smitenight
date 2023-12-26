namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

public record class GodAltAbilityDto
{
    public required string AltName { get; init; }
    public required string AltPosition { get; init; }
    public required string God { get; init; }
    public required int GodId { get; init; }
    public required int ItemId { get; init; }
    public string? RetMsg { get; init; }
}
