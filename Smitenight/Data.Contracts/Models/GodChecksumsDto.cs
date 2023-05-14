namespace Smitenight.Persistence.Data.Contracts.Models
{
    public class GodChecksumsDto
    {
        public int GodId { get; set; }
        public int GodSmiteId { get; set; }

        public string GodChecksum { get; set; } = null!;
        public string Ability1Checksum { get; set; } = null!;
        public string Ability2Checksum { get; set; } = null!;
        public string Ability3Checksum { get; set; } = null!;
        public string Ability4Checksum { get; set; } = null!;
        public string Ability5Checksum { get; set; } = null!;
        public string BasicAttackDescriptionChecksum { get; set; } = null!;
    }
}
