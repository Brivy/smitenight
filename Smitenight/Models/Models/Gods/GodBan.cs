using Smitenight.Domain.Models.Enums.Gods;
using Smitenight.Domain.Models.Interfaces;
using Smitenight.Domain.Models.Models.Matches;

namespace Smitenight.Domain.Models.Models.Gods
{
    public class GodBan : IEntity
    {
        public int Id { get; set; }
        public int GodId { get; set; }
        public int MatchId { get; set; }

        public GodBanOrderEnum GodBanOrder { get; set; }

        #region Navigation

        public God? God { get; set; }
        public Match? Match { get; set; }

        #endregion
    }
}
