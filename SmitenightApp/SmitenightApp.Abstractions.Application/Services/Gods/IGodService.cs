using SmitenightApp.Domain.Contracts.Common;
using SmitenightApp.Domain.Contracts.Gods;

namespace SmitenightApp.Abstractions.Application.Services.Gods;

public interface IGodService
{
    Task<ServerResponseDto<List<GodSkinDto>>> ListHomeLoadingSkinsAsync(CancellationToken cancellationToken = default);
}