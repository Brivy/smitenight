namespace Smitenight.Application.Blazor.Business.Extensions
{
    public static class IntegerExtensions
    {
        public static bool ConvertToBool(this int integer) => integer == 1;
    }
}
