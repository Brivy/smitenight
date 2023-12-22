using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }

        public string GameMap { get; set; } = null!;
        public GameModeQueue GameModeQueue { get; set; }
        public int MatchDuration { get; set; }
        public int? TeamOneScore { get; set; }
        public int? TeamTwoScore { get; set; }
        public string Name { get; set; } = null!;
        public string Region { get; set; } = null!;
        public DateTimeOffset StartDate { get; set; }

        public ICollection<GodBan> GodBans { get; set; }
        public ICollection<MatchDetail> MatchDetails { get; set; }
        public ICollection<SmitenightMatch> SmitenightMatches { get; set; }

        public Match()
        {
            GodBans = new List<GodBan>();
            MatchDetails = new List<MatchDetail>();
            SmitenightMatches = new List<SmitenightMatch>();
        }
    }
}
