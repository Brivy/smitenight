namespace Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient
{
    public record class SearchTeamsDto
    (
        string? Founder,
        string? Name,
        int Players,
        string? Tag,
        int TeamId,
        string? RetMsg
    );
}
