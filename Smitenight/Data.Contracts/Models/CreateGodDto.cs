using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.Contracts.Models
{
    public record CreateGodDto
    {
        public int SmiteId { get; set; }
        public float AttackSpeed { get; set; }
        public float AttackSpeedPerLevel { get; set; }
        public bool AutoBanned { get; set; }
        public string GodCardUrl { get; set; } = null!;
        public string GodIconUrl { get; set; } = null!;
        public float Hp5PerLevel { get; set; }
        public int Health { get; set; }
        public int HealthPerFive { get; set; }
        public int HealthPerLevel { get; set; }
        public bool LatestGod { get; set; }
        public string Lore { get; set; } = null!;
        public float Mp5PerLevel { get; set; }
        public float MagicProtection { get; set; }
        public float MagicProtectionPerLevel { get; set; }
        public int MagicalPower { get; set; }
        public float MagicalPowerPerLevel { get; set; }
        public int Mana { get; set; }
        public float ManaPerFive { get; set; }
        public int ManaPerLevel { get; set; }
        public string Name { get; set; } = null!;
        public bool OnFreeRotation { get; set; }
        public string Pantheon { get; set; } = null!;
        public int PhysicalPower { get; set; }
        public float PhysicalPowerPerLevel { get; set; }
        public float PhysicalProtection { get; set; }
        public float PhysicalProtectionPerLevel { get; set; }
        public string Pros { get; set; } = null!;
        public GodRole Role { get; set; }
        public int Speed { get; set; }
        public string Title { get; set; } = null!;
        public GodType Type { get; set; }
    }
}
