using Smitenight.Domain.Enums.SmiteClient;
using Smitenight.Domain.Interfaces;
using Smitenight.Domain.Models.Gods;

namespace Smitenight.Domain.Models.Matches
{
    public class Match : IEntity
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }

        public string GameMap { get; set; } = null!;
        public GameModeQueueIdEnum GameModeQueue { get; set; }
        public int MatchDuration { get; set; }
        public int TeamOneScore { get; set; }
        public int TeamTwoScore { get; set; }
        public string Name { get; set; } = null!;
        public string Region { get; set; } = null!;
        public DateTime StartDate { get; set; }

        #region Navigation

        public List<GodBan> GodBans { get; set; }
        public List<MatchDetail> MatchDetails { get; set; }

        #endregion

        public Match()
        {
            GodBans = new List<GodBan>();
            MatchDetails = new List<MatchDetail>();
        }
    }
}
