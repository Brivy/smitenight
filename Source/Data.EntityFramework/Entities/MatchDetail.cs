using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class MatchDetail
    {
        public int Id { get; set; }
        public int GodId { get; set; }
        public int GodSkinId { get; set; }
        public int MatchId { get; set; }
        public int PartyId { get; set; } // Not (yet) linked to an entity
        public int? PlayerId { get; set; } // In case of privacy set to 'true' this can be null
        public int? TeamId { get; set; } // Not (yet) linked to an entity

        // Damage stuff
        public int DamageDone { get; set; }
        public int DamageDoneInHand { get; set; }
        public int DamageDoneMagical { get; set; }
        public int DamageDonePhysical { get; set; }
        public int DamageDoneToBots { get; set; }
        public int DamageDoneToStructures { get; set; }
        public int DamageTaken { get; set; }
        public int DamageTakenMagical { get; set; }
        public int DamageTakenPhysical { get; set; }
        public int DamageMitigated { get; set; }

        // Kill stuff
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public int FirstBlood { get; set; }
        public int SingleKills { get; set; }
        public int DoubleKills { get; set; }
        public int TripleKills { get; set; }
        public int QuadraKills { get; set; }
        public int PentaKills { get; set; }
        public int HighestMultiKill { get; set; }
        public int KillingSpree { get; set; }
        public int BotKills { get; set; }
        public int PlayerKills { get; set; }
        public int FireGiantKills { get; set; }
        public int GoldFuryKills { get; set; }
        public int PhoenixKills { get; set; }
        public int SiegeJuggernautKills { get; set; }
        public int TowerKills { get; set; }
        public int WildJuggernautKills { get; set; }
        public int ObjectiveAssists { get; set; }

        public int DistanceTraveled { get; set; }
        public GodRole GodRole { get; set; }
        public int GoldEarned { get; set; }
        public int GoldEarnedPerMinute { get; set; }
        public int HealingDone { get; set; }
        public int HealingDoneToBots { get; set; }
        public int HealingDoneToSelf { get; set; }
        public int LevelReached { get; set; }
        public MatchTeam MatchTeam { get; set; }
        public bool Surrendered { get; set; }
        public int TotalTimeDead { get; set; }
        public int WardsPlaced { get; set; }
        public bool Winner { get; set; }

        public God? God { get; set; }
        public GodSkin? GodSkin { get; set; }
        public Match? Match { get; set; }
        public Player? Player { get; set; }
        public IEnumerable<ActivePurchase> ActivePurchases { get; set; }
        public IEnumerable<ItemPurchase> ItemPurchases { get; set; }

        public MatchDetail()
        {
            ActivePurchases = new List<ActivePurchase>();
            ItemPurchases = new List<ItemPurchase>();
        }
    }
}
