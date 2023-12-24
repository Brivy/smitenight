namespace Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;

public record class CreateSmiteSessionDto
{
    public string? RetMsg { get; init; } = null!;
    public string SessionId { get; init; } = null!;
    public string Timestamp { get; init; } = null!;
}
