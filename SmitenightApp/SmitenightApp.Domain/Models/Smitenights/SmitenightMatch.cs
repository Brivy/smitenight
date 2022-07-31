using SmitenightApp.Domain.Exceptions;
using SmitenightApp.Domain.Interfaces;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Domain.Models.Smitenights
{
    public class SmitenightMatch : IEntity
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int SmitenightId { get; set; }

        #region Navigation

        private Match? _match;
        private Smitenight? _smitenight;

        public Match Match
        {
            get => _match ?? throw new NavigationPropertyNullException(nameof(Match));
            set => _match = value;
        }

        public Smitenight Smitenight
        {
            get => _smitenight ?? throw new NavigationPropertyNullException(nameof(Smitenight));
            set => _smitenight = value;
        }

        #endregion

        public SmitenightMatch()
        {

        }
    }
}
