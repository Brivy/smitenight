namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class BasicAttackDescription
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
