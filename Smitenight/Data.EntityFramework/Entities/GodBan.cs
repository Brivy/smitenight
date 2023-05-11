using Smitenight.Domain.Models.Enums.Gods;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class GodBan
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
