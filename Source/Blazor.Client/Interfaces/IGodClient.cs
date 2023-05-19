using Smitenight.Domain.Models.Contracts.Common;
using Smitenight.Domain.Models.Contracts.Gods;

namespace Smitenight.Presentation.Blazor.Client.Interfaces;

public interface IGodClient
{
    Task<ServerResponseDto<List<GodSkinDto>>> ListHomeLoadingSkinsAsync(CancellationToken cancellationToken = default);
}