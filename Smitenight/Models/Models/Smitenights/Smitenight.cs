using Smitenight.Domain.Models.Interfaces;
using Smitenight.Domain.Models.Models.Players;

namespace Smitenight.Domain.Models.Models.Smitenights
{
    public class Smitenight : IEntity
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? PinCode { get; set; }

        #region Navigation

        public Player? Player { get; set; }
        public List<SmitenightMatch> SmitenightMatches { get; set; }

        #endregion

        public Smitenight()
        {
            SmitenightMatches = new List<SmitenightMatch>();
        }
    }
}