using SmitenightApp.Domain.Enums.Gods;
using SmitenightApp.Domain.Interfaces;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Domain.Models.Gods
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
