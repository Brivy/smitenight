namespace Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;

public record class CreateSmiteSessionDto
{
    public string? RetMsg { get; init; }
    public required string SessionId { get; init; }
    public required string Timestamp { get; init; }
}
