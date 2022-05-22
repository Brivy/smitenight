using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.MatchInfoResponses
{
    public record class MatchPlayersDetailsResponseDto
    {
        [JsonPropertyName("Account_Gods_Played")]
        public int AccountGodsPlayed { get; init; }
        [JsonPropertyName("Account_Level")]
        public int AccountLevel { get; init; }
        [JsonPropertyName("GodId")]
        public int GodId { get; init; }
        [JsonPropertyName("GodLevel")]
        public int GodLevel { get; init; }
        [JsonPropertyName("GodName")]
        public string? GodName { get; init; }
        [JsonPropertyName("Mastery_Level")]
        public int MasteryLevel { get; init; }
        [JsonPropertyName("Match")]
        public int Match { get; init; }
        [JsonPropertyName("Queue")]
        public string? Queue { get; init; }
        [JsonPropertyName("Rank_Stat")]
        public int RankStat { get; init; }
        [JsonPropertyName("SkinId")]
        public int SkinId { get; init; }
        [JsonPropertyName("Tier")]
        public int Tier { get; init; }
        [JsonPropertyName("mapGame")]
        public string? MapGame { get; init; }
        [JsonPropertyName("playerCreated")]
        public string? PlayerCreated { get; init; }
        [JsonPropertyName("playerId")]
        public string? PlayerId { get; init; }
        [JsonPropertyName("playerName")]
        public string? PlayerName { get; init; }
        [JsonPropertyName("playerRegion")]
        public string? PlayerRegion { get; init; }
        [JsonPropertyName("ret_msg")]
        public object? RetMsg { get; init; }
        [JsonPropertyName("taskForce")]
        public int TaskForce { get; init; }
        [JsonPropertyName("tierLosses")]
        public int TierLosses { get; init; }
        [JsonPropertyName("tierPoints")]
        public int TierPoints { get; init; }
        [JsonPropertyName("tierWins")]
        public int TierWins { get; init; }
    }
}
