using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities;

internal class Ability
{
    public int Id { get; set; }
    public int GodId { get; set; }
    public int SmiteId { get; set; }
    public int PatchId { get; set; }

    public string Checksum { get; set; } = null!;
    public string? Cooldown { get; set; }
    public string? Cost { get; set; }
    public string Description { get; set; } = null!;
    public string Summary { get; set; } = null!;
    public string Url { get; set; } = null!;
    public AbilityType AbilityType { get; set; }
    public bool Latest { get; set; }

    public God? God { get; set; }
    public Patch? Patch { get; set; }
    public ICollection<AbilityRank> AbilityRanks { get; set; }
    public ICollection<AbilityTag> AbilityTags { get; set; }

    public Ability()
    {
        AbilityRanks = new List<AbilityRank>();
        AbilityTags = new List<AbilityTag>();
    }
}
