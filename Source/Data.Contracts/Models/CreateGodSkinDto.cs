using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.Contracts.Models;

public class CreateGodSkinDto
{
    public int SmiteId { get; set; }
    public string Checksum { get; set; } = null!;
    public int SecondarySmiteId { get; set; }
    public string? GodSkinUrl { get; set; }
    public string Name { get; set; } = null!;
    public GodSkinsObtainability Obtainability { get; set; }
    public int PriceFavor { get; set; }
    public int PriceGems { get; set; }
}
