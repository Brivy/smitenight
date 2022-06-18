using Smitenight.Domain.Interfaces;
using Smitenight.Domain.Models.Abilities;

namespace Smitenight.Domain.Models.Gods
{
    public class God : IEntity
    {
        public int Id { get; set; }

        public float AttackSpeed { get; set; }
        public float AttackSpeedPerLevel { get; set; }
        public string AutoBanned { get; set; }
        public string Cons { get; set; }
        public string GodCardUrl { get; set; }
        public string GodIconUrl { get; set; }
        public float Hp5PerLevel { get; set; }
        public int Health { get; set; }
        public int HealthPerFive { get; set; }
        public int HealthPerLevel { get; set; }
        public string LatestGod { get; set; }
        public string Lore { get; set; }
        public float Mp5PerLevel { get; set; }
        public int MagicProtection { get; set; }
        public float MagicProtectionPerLevel { get; set; }
        public int MagicalPower { get; set; }
        public float MagicalPowerPerLevel { get; set; }
        public int Mana { get; set; }
        public float ManaPerFive { get; set; }
        public int ManaPerLevel { get; set; }
        public string Name { get; set; }
        public string OnFreeRotation { get; set; }
        public string Pantheon { get; set; }
        public int PhysicalPower { get; set; }
        public float PhysicalPowerPerLevel { get; set; }
        public int PhysicalProtection { get; set; }
        public float PhysicalProtectionPerLevel { get; set; }
        public string Pros { get; set; }
        public string Roles { get; set; }
        public int Speed { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        #region Navigation

        public List<BasicAttackDescription> BasicAttackDescriptions { get; set; }
        public List<Ability> Abilities { get; set; }

        #endregion

        public God(string autoBanned, string cons, string godCardUrl, string godIconUrl, string latestGod, string lore, string name, string onFreeRotation, string pantheon, string pros, string roles, string title, string type)
        {
            AutoBanned = autoBanned;
            Cons = cons;
            GodCardUrl = godCardUrl;
            GodIconUrl = godIconUrl;
            LatestGod = latestGod;
            Lore = lore;
            Name = name;
            OnFreeRotation = onFreeRotation;
            Pantheon = pantheon;
            Pros = pros;
            Roles = roles;
            Title = title;
            Type = type;
            BasicAttackDescriptions = new List<BasicAttackDescription>();
            Abilities = new List<Ability>();
        }
    }
}
