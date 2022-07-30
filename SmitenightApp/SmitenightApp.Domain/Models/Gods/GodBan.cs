using SmitenightApp.Domain.Enums.Gods;
using SmitenightApp.Domain.Exceptions;
using SmitenightApp.Domain.Interfaces;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Domain.Models.Gods
{
    public class GodBan : IEntity
    {
        public int Id { get; set; }
        public int GodId { get; set; }
        public int MatchId { get; set; }

        public GodBanOrderEnum GodBanOrder { get; set; }

        #region Navigation

        private God? _god;
        private Match? _match;

        public God God
        {
            get => _god ?? throw new NavigationPropertyNullException(nameof(God));
            set => _god = value;
        }

        public Match Match
        {
            get => _match ?? throw new NavigationPropertyNullException(nameof(Match));
            set => _match = value;
        }

        #endregion

        public GodBan()
        {

        }
    }
}
