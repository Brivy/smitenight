namespace Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;

public record class PatchInfoDto
{
    public string? RetMsg { get; init; }
    public required string VersionString { get; init; }
}
