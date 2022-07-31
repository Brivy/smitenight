using SmitenightApp.Abstractions.Application.Services.Common;

namespace SmitenightApp.Application.Services.Common
{
    public class Clock : IClock
    {
        public DateTime Now() => DateTime.Now;
    }
}
