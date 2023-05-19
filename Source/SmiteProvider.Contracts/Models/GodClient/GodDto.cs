namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient
{
    public record class GodDto
    {
        public string Ability1 { get; init; } = null!;
        public string Ability2 { get; init; } = null!;
        public string Ability3 { get; init; } = null!;
        public string Ability4 { get; init; } = null!;
        public string Ability5 { get; init; } = null!;
        public int AbilityId1 { get; init; }
        public int AbilityId2 { get; init; }
        public int AbilityId3 { get; init; }
        public int AbilityId4 { get; init; }
        public int AbilityId5 { get; init; }
        public AbilityDetailsDto AbilityDetails1 { get; init; } = null!;
        public AbilityDetailsDto AbilityDetails2 { get; init; } = null!;
        public AbilityDetailsDto AbilityDetails3 { get; init; } = null!;
        public AbilityDetailsDto AbilityDetails4 { get; init; } = null!;
        public AbilityDetailsDto AbilityDetails5 { get; init; } = null!;
        public float AttackSpeed { get; init; }
        public float AttackSpeedPerLevel { get; init; }
        public string AutoBanned { get; init; } = null!;
        public string Cons { get; init; } = null!;
        public float Hp5PerLevel { get; init; }
        public int Health { get; init; }
        public int HealthPerFive { get; init; }
        public int HealthPerLevel { get; init; }
        public string Lore { get; init; } = null!;
        public float Mp5PerLevel { get; init; }
        public float MagicProtection { get; init; }
        public float MagicProtectionPerLevel { get; init; }
        public int MagicalPower { get; init; }
        public float MagicalPowerPerLevel { get; init; }
        public int Mana { get; init; }
        public float ManaPerFive { get; init; }
        public int ManaPerLevel { get; init; }
        public string Name { get; init; } = null!;
        public string OnFreeRotation { get; init; } = null!;
        public string Pantheon { get; init; } = null!;
        public int PhysicalPower { get; init; }
        public float PhysicalPowerPerLevel { get; init; }
        public float PhysicalProtection { get; init; }
        public float PhysicalProtectionPerLevel { get; init; }
        public string Pros { get; init; } = null!;
        public string Roles { get; init; } = null!;
        public int Speed { get; init; }
        public string Title { get; init; } = null!;
        public string Type { get; init; } = null!;
        public AbilityDescriptionDto AbilityDescription1 { get; init; } = null!;
        public AbilityDescriptionDto AbilityDescription2 { get; init; } = null!;
        public AbilityDescriptionDto AbilityDescription3 { get; init; } = null!;
        public AbilityDescriptionDto AbilityDescription4 { get; init; } = null!;
        public AbilityDescriptionDto AbilityDescription5 { get; init; } = null!;
        public BasicAttackDto BasicAttack { get; init; } = null!;
        public string GodAbility1Url { get; init; } = null!;
        public string GodAbility2Url { get; init; } = null!;
        public string GodAbility3Url { get; init; } = null!;
        public string GodAbility4Url { get; init; } = null!;
        public string GodAbility5Url { get; init; } = null!;
        public string GodCardUrl { get; init; } = null!;
        public string GodIconUrl { get; init; } = null!;
        public int Id { get; init; }
        public string LatestGod { get; init; } = null!;
        public string? RetMsg { get; init; }
    }
}
