namespace Smitenight.Persistence.Data.Contracts.Models;

public record CreatePatchDto
{
    public required string Version { get; init; }
    public required DateTimeOffset ReleaseDate { get; init; }
}
