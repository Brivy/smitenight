using Smitenight.Domain.Interfaces;
using Smitenight.Domain.Models.Matches;

namespace Smitenight.Domain.Models.Teams
{
    public class Team : IEntity
    {
        public int Id { get; set; }
        public int SmiteId { get; set; }

        public string Name { get; set; } = null!;

        #region Navigation

        public List<MatchDetail> MatchDetails { get; set; }

        #endregion

        public Team()
        {
            MatchDetails = new List<MatchDetail>();
        }
    }
}
