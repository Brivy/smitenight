using Smitenight.Domain.Models.Contracts.Gods;
using Smitenight.Domain.Models.Contracts.Items;
using Smitenight.Domain.Models.Contracts.Players;
using Smitenight.Domain.Models.Enums.Gods;
using Smitenight.Domain.Models.Enums.Matches;

namespace Smitenight.Domain.Models.Contracts.Matches
{
    public class MatchDetailDto
    {
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
        public GodRoleEnum GodRole { get; set; }
        public int GoldEarned { get; set; }
        public int GoldEarnedPerMinute { get; set; }
        public int HealingDone { get; set; }
        public int HealingDoneToBots { get; set; }
        public int HealingDoneToSelf { get; set; }
        public int LevelReached { get; set; }
        public MatchTeamEnum MatchTeam { get; set; }
        public bool Surrendered { get; set; }
        public int TotalTimeDead { get; set; }
        public int WardsPlaced { get; set; }
        public bool Winner { get; set; }

        public GodDto? God { get; set; }
        public GodSkinDto? GodSkin { get; set; }
        public MatchDto? Match { get; set; }
        public PlayerDto? Player { get; set; }

        public List<ActivePurchaseDto> ActivePurchases { get; set; }
        public List<ItemPurchaseDto> ItemPurchases { get; set; }

        public MatchDetailDto()
        {
            ActivePurchases = new List<ActivePurchaseDto>();
            ItemPurchases = new List<ItemPurchaseDto>();
        }
    }
}
