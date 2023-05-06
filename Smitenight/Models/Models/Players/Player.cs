using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Domain.Models.Interfaces;
using Smitenight.Domain.Models.Models.Matches;

namespace Smitenight.Domain.Models.Models.Players
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
        public List<Domain.Models.Models.Smitenights.Smitenight> Smitenights { get; set; }

        #endregion

        public Player()
        {
            MatchDetails = new List<MatchDetail>();
            Smitenights = new List<Domain.Models.Models.Smitenights.Smitenight>();
        }
    }
}
