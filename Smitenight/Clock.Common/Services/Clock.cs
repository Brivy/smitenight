using Clock.Common.Contracts;

namespace Clock.Common.Services
{
    public class Clock : IClock
    {
        public DateTime UtcNow() => DateTime.UtcNow;
    }
}
