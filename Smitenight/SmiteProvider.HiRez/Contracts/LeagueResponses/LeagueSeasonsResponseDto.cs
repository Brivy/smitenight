using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Contracts.LeagueResponses
{
    public record class LeagueSeasonsResponseDto
    {
        [JsonPropertyName("complete")] public bool Complete { get; set; }
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("league_description")] public string? LeagueDescription { get; set; }
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
        [JsonPropertyName("round")] public int Round { get; set; }
        [JsonPropertyName("season")] public int Season { get; set; }
    }
}
