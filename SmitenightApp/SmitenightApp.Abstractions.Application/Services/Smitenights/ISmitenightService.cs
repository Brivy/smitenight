using SmitenightApp.Domain.Contracts.Common;
using SmitenightApp.Domain.Contracts.Smitenights;

namespace SmitenightApp.Abstractions.Application.Services.Smitenights;

public interface ISmitenightService
{
    Task<ServerResponseDto<SmitenightDto>> StartSmitenightAsync(string playerName, CancellationToken cancellationToken = default);
    Task<ServerResponseDto<SmitenightDto>> EndSmitenightAsync(string playerName, CancellationToken cancellationToken = default);
}