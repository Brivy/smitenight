using Smitenight.Domain.Models.Interfaces;

namespace Smitenight.Domain.Models.Models.Gods
{
    public class BasicAttackDescription : IEntity
    {
        public int Id { get; set; }
        public int GodId { get; set; }

        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        #region Navigation

        public God? God { get; set; }

        #endregion
    }
}
