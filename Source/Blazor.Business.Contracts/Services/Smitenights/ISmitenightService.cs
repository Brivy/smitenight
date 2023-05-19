using Smitenight.Domain.Models.Contracts.Common;
using Smitenight.Domain.Models.Contracts.Smitenights;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Smitenights;

public interface ISmitenightService
{
    Task<ServerResponseDto<SmitenightDto>> StartSmitenightAsync(string playerName, string? pinCode, CancellationToken cancellationToken = default);
    Task<ServerResponseDto<SmitenightDto>> EndSmitenightAsync(string playerName, string? pinCode, CancellationToken cancellationToken = default);
}