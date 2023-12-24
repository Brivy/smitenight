using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.OtherClient;

public record class Motd
{
    [JsonPropertyName("description")] public string? Description { get; init; }
    [JsonPropertyName("gameMode")] public string? GameMode { get; init; }
    [JsonPropertyName("maxPlayers")] public string? MaxPlayers { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("ret_msg")] public string? RetMsg { get; init; }
    [JsonPropertyName("startDateTime")] public string? StartDateTime { get; init; }
    [JsonPropertyName("team1GodsCSV")] public string? Team1GodsCsv { get; init; }
    [JsonPropertyName("team2GodsCSV")] public string? Team2GodsCsv { get; init; }
    [JsonPropertyName("title")] public string? Title { get; init; }
}
