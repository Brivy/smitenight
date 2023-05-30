using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.Contracts.Models
{
    public record CreateAbilityDto
    {
        public int SmiteId { get; set; }
        public string Checksum { get; set; } = null!;
        public string? Cooldown { get; set; }
        public string? Cost { get; set; }
        public string Description { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Url { get; set; } = null!;
        public AbilityType AbilityType { get; set; }
        public IEnumerable<CreateAbilityRankDto> AbilityRanks { get; set; } = new List<CreateAbilityRankDto>();
        public IEnumerable<CreateAbilityTagDto> AbilityTags { get; set; } = new List<CreateAbilityTagDto>();
    }
}
