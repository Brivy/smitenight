using Smitenight.Domain.Enums.SmiteClient;
using Smitenight.Domain.Interfaces;
using Smitenight.Domain.Models.Matches;

namespace Smitenight.Domain.Models.Players
{
    public class Player : IEntity
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }
        public int? SmitePortalUserId { get; set; }

        public string HirezPlayerName { get; set; } = null!;
        public int Level { get; set; }
        public int MasteryLevel { get; set; }
        public string PlayerName { get; set; } = null!;
        public PortalTypeEnum PortalType { get; set; }

        #region Navigation

        public List<MatchDetail> MatchDetails { get; set; }

        #endregion

        public Player()
        {
            MatchDetails = new List<MatchDetail>();
        }
    }
}
