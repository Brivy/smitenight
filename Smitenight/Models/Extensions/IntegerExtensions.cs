namespace Smitenight.Domain.Models.Extensions
{
    public static class IntegerExtensions
    {
        public static bool ConvertToBool(this int integer) => integer == 1;
    }
}
