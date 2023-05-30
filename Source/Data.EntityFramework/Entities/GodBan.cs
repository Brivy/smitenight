using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class GodBan
    {
        public int Id { get; set; }
        public int GodId { get; set; }
        public int MatchId { get; set; }

        public GodBanOrder GodBanOrder { get; set; }

        public God? God { get; set; }
        public Match? Match { get; set; }
    }
}
