using SmitenightApp.Domain.Exceptions;
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

        #region Navigation

        private Player? _player;

        public Player Player
        {
            get => _player ?? throw new NavigationPropertyNullException(nameof(Player));
            set => _player = value;
        }

        public List<SmitenightMatch> SmitenightMatches { get; set; }

        #endregion

        public Smitenight()
        {
            SmitenightMatches = new List<SmitenightMatch>();
        }
    }
}