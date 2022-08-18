using SmitenightApp.Domain.Contracts.Common;
using SmitenightApp.Domain.Contracts.Gods;

namespace SmitenightApp.Client.Interfaces;

public interface IGodClient
{
    Task<ServerResponseDto<List<GodSkinDto>>> ListHomeLoadingSkinsAsync(CancellationToken cancellationToken = default);
}