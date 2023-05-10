namespace Smitenight.Domain.Models.Clients.OtherClient
{
    public record class Motd
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
