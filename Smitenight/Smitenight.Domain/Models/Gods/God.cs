using Smitenight.Domain.Interfaces;
using Smitenight.Domain.Models.Abilities;

namespace Smitenight.Domain.Models.Gods
{
    public class God : IEntity
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }

        public float AttackSpeed { get; set; }
        public float AttackSpeedPerLevel { get; set; }
        public string AutoBanned { get; set; } = null!;
        public string Cons { get; set; } = null!;
        public string GodCardUrl { get; set; } = null!;
        public string GodIconUrl { get; set; } = null!;
        public float Hp5PerLevel { get; set; }
        public int Health { get; set; }
        public int HealthPerFive { get; set; }
        public int HealthPerLevel { get; set; }
        public string LatestGod { get; set; } = null!;
        public string Lore { get; set; } = null!;
        public float Mp5PerLevel { get; set; }
        public int MagicProtection { get; set; }
        public float MagicProtectionPerLevel { get; set; }
        public int MagicalPower { get; set; }
        public float MagicalPowerPerLevel { get; set; }
        public int Mana { get; set; }
        public float ManaPerFive { get; set; }
        public int ManaPerLevel { get; set; }
        public string Name { get; set; } = null!;
        public string OnFreeRotation { get; set; } = null!;
        public string Pantheon { get; set; } = null!;
        public int PhysicalPower { get; set; }
        public float PhysicalPowerPerLevel { get; set; }
        public int PhysicalProtection { get; set; }
        public float PhysicalProtectionPerLevel { get; set; }
        public string Pros { get; set; } = null!;
        public string Roles { get; set; } = null!;
        public int Speed { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;

        #region Navigation

        public List<BasicAttackDescription> BasicAttackDescriptions { get; set; }
        public List<Ability> Abilities { get; set; }

        #endregion

        public God()
        {
            BasicAttackDescriptions = new List<BasicAttackDescription>();
            Abilities = new List<Ability>();
        }
    }
}
