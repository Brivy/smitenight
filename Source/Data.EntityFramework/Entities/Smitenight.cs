namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class Smitenight
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? PinCode { get; set; }

        public Player? Player { get; set; }
        public IEnumerable<SmitenightMatch> SmitenightMatches { get; set; }

        public Smitenight()
        {
            SmitenightMatches = new List<SmitenightMatch>();
        }
    }
}