namespace Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;

public record class HirezServerStatusDto
{
    public required string EntryDatetime { get; init; }
    public required string Environment { get; init; }
    public required bool LimitedAccess { get; init; }
    public required string Platform { get; init; }
    public string? RetMsg { get; init; }
    public required string Status { get; init; }
    public required string Version { get; init; }
}
