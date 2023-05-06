using Smitenight.Domain.Models.Interfaces;

namespace Smitenight.Domain.Models.Models.Players
{
    public class PlayerNameAttempt : IEntity
    {
        public int Id { get; set; }

        public string PlayerName { get; set; } = null!;
        public int Attempts { get; set; }
        public DateTime FirstTimeUsed { get; set; }
        public DateTime LastTimeUsed { get; set; }
        public DateTime NextAttemptPossibleAt { get; set; }
    }
}
