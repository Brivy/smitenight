using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface ISmiteSessionClient
{
    Task<CreateSmiteSessionDto> CreateSmiteSessionAsync(CancellationToken cancellationToken = default);
}
