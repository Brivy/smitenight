namespace Smitenight.Providers.SmiteProvider.HiRez.Services;

public interface ISmiteHashService
{
    string GenerateSmiteHash(string methodName, string utcDateString);
}
