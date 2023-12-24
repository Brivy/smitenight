using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities;

public class GodSkin
{
    public int Id { get; set; }
    public int GodId { get; set; }
    public int SmiteId { get; set; }
    public int SecondarySmiteId { get; set; }
    public int PatchId { get; set; }

    public string Checksum { get; set; } = null!;
    public string? GodSkinUrl { get; set; }
    public string Name { get; set; } = null!;
    public GodSkinsObtainability Obtainability { get; set; }
    public int PriceFavor { get; set; }
    public int PriceGems { get; set; }
    public bool Latest { get; set; }

    public Patch? Patch { get; set; }
    public God? God { get; set; }
    public ICollection<MatchDetail> MatchDetails { get; set; }

    public GodSkin()
    {
        MatchDetails = new List<MatchDetail>();
    }
}
