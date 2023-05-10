namespace Smitenight.Providers.SmiteProvider.HiRez.Services
{
    public interface ISmiteClientUrlService
    {
        string ConstructPingUrl();

        Task<string> ConstructUrlAsync(string methodName, CancellationToken cancellationToken = default);

        Task<string> ConstructUrlAsync(string methodName, string urlPath, CancellationToken cancellationToken = default);

        string ConstructUrlPath(params object[] urlPaths);
    }
}