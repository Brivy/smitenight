namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class SmitenightMatch
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
