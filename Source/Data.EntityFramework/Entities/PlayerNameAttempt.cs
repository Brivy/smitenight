namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class PlayerNameAttempt
    {
        public int Id { get; set; }

        public string PlayerName { get; set; } = null!;
        public int Attempts { get; set; }
        public DateTimeOffset FirstTimeUsed { get; set; }
        public DateTimeOffset LastTimeUsed { get; set; }
        public DateTimeOffset NextAttemptPossibleAt { get; set; }
    }
}
