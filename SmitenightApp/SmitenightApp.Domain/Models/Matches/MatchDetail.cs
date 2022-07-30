using SmitenightApp.Domain.Enums.Gods;
using SmitenightApp.Domain.Enums.Matches;
using SmitenightApp.Domain.Exceptions;
using SmitenightApp.Domain.Models.Gods;
using SmitenightApp.Domain.Models.Items;
using SmitenightApp.Domain.Models.Players;

namespace SmitenightApp.Domain.Models.Matches
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

        #region Navigation

        private God? _god;
        private GodSkin? _godSkin;
        private Match? _match;
        private Player? _player;
        
        public God God
        {
            get => _god ?? throw new NavigationPropertyNullException(nameof(God));
            set => _god = value;
        }
        
        public GodSkin GodSkin
        {
            get => _godSkin ?? throw new NavigationPropertyNullException(nameof(GodSkin));
            set => _godSkin = value;
        }

        public Match Match
        {
            get => _match ?? throw new NavigationPropertyNullException(nameof(Match));
            set => _match = value;
        }
        
        public Player? Player
        {
            get => _player ?? throw new NavigationPropertyNullException(nameof(Player));
            set => _player = value;
        }

        public List<ActivePurchase> ActivePurchases { get; set; }
        public List<ItemPurchase> ItemPurchases { get; set; }

        #endregion

        public MatchDetail()
        {
            ActivePurchases = new List<ActivePurchase>();
            ItemPurchases = new List<ItemPurchase>();
        }
    }
}
