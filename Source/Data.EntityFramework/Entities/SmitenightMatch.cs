namespace Smitenight.Persistence.Data.EntityFramework.Entities;

internal class SmitenightMatch
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public int SmitenightId { get; set; }

    public Match? Match { get; set; }
    public Smitenight? Smitenight { get; set; }
}
