using SmitenightApp.Domain.Interfaces;
using SmitenightApp.Domain.Models.Players;

namespace SmitenightApp.Domain.Models.Smitenights
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