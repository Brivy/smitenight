namespace Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient
{
    public record class MotdDto
    (
        string? Description,
        string? GameMode,
        string? MaxPlayers,
        string? Name,
        string? RetMsg,
        string? StartDateTime,
        string? Team1GodsCsv,
        string? Team2GodsCsv,
        string? Title
    );
}
