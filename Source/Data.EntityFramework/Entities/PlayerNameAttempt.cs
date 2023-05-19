namespace Smitenight.Persistence.Data.EntityFramework.Entities
{
    public class PlayerNameAttempt
    {
        public int Id { get; set; }

        public string PlayerName { get; set; } = null!;
        public int Attempts { get; set; }
        public DateTime FirstTimeUsed { get; set; }
        public DateTime LastTimeUsed { get; set; }
        public DateTime NextAttemptPossibleAt { get; set; }
    }
}
