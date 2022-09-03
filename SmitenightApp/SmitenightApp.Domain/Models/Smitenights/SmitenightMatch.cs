using SmitenightApp.Domain.Interfaces;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Domain.Models.Smitenights
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
