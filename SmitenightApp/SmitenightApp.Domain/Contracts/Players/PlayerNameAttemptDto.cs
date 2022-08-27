namespace SmitenightApp.Domain.Contracts.Players
{
    public class PlayerNameAttemptDto
    {
        public string PlayerName { get; set; } = null!;
        public int Attempts { get; set; }
        public DateTime FirstTimeUsed { get; set; }
        public DateTime NextAttemptPossibleAt { get; set; }
    }
}
