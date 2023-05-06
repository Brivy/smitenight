using Smitenight.Application.Blazor.Business.Contracts.Services.Common;

namespace Smitenight.Application.Blazor.Business.Services.Common
{
    public class Clock : IClock
    {
        public DateTime Now() => DateTime.UtcNow;
    }
}
