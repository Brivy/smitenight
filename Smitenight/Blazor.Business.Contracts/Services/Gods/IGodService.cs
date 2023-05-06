using Smitenight.Domain.Models.Contracts.Common;
using Smitenight.Domain.Models.Contracts.Gods;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Gods;

public interface IGodService
{
    Task<ServerResponseDto<List<GodSkinDto>>> ListHomeLoadingSkinsAsync(CancellationToken cancellationToken = default);
}