using SmitenightApp.Domain.Enums.SmiteClient;
using SmitenightApp.Domain.Interfaces;
using SmitenightApp.Domain.Models.Matches;
using SmitenightApp.Domain.Models.Smitenights;

namespace SmitenightApp.Domain.Models.Players
{
    public class Player : IEntity
    {
        public int Id { get; set; }
        public int? SmiteId { get; set; }
        public int? LastSynchronizedMatchId { get; set; }
        public long? SmitePortalUserId { get; set; }

        public string? HirezGamerTag { get; set; }
        public string? HirezPlayerName { get; set; }
        public int Level { get; set; }
        public int MasteryLevel { get; set; }
        public string? PlayerName { get; set; }
        public PortalTypeEnum? PortalType { get; set; }
        public bool PrivacyEnabled { get; set; }

        #region Navigation

        public List<MatchDetail> MatchDetails { get; set; }
        public List<Smitenight> Smitenights { get; set; }

        #endregion

        public Player()
        {
            MatchDetails = new List<MatchDetail>();
            Smitenights = new List<Smitenight>();
        }
    }
}
