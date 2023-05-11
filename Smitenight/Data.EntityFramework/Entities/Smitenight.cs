namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class Smitenight
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