namespace Smitenight.Application.Services.Common
{
    public class Clock : IClock
    {
        public DateTime Now() => DateTime.Now;
    }
}
