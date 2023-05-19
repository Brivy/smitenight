using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.Common
{
    public record class CommonItem
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
    }
}
