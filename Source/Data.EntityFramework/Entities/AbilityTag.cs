namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class AbilityTag
    {
        public int Id { get; set; }
        public int AbilityId { get; set; }

        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        public Ability? Ability { get; set; }
    }
}
