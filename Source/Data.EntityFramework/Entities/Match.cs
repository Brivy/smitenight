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
        public DateTime StartDate { get; set; }

        public IEnumerable<GodBan> GodBans { get; set; }
        public IEnumerable<MatchDetail> MatchDetails { get; set; }
        public IEnumerable<SmitenightMatch> SmitenightMatches { get; set; }

        public Match()
        {
            GodBans = new List<GodBan>();
            MatchDetails = new List<MatchDetail>();
            SmitenightMatches = new List<SmitenightMatch>();
        }
    }
}
