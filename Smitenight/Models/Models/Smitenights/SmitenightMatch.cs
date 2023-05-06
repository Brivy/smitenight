using Smitenight.Domain.Models.Interfaces;
using Smitenight.Domain.Models.Models.Matches;

namespace Smitenight.Domain.Models.Models.Smitenights
{
    public class SmitenightMatch : IEntity
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int SmitenightId { get; set; }

        #region Navigation

        public Match? Match { get; set; }
        public Smitenight? Smitenight { get; set; }

        #endregion
    }
}
