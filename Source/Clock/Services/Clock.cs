using Smitenight.Utilities.Clock.Contracts.Contracts;

namespace Smitenight.Utilities.Clock.Services
{
    public class Clock : IClock
    {
        public DateTime UtcNow() => DateTime.UtcNow;
    }
}
