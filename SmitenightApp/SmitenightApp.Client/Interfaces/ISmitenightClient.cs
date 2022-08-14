using SmitenightApp.Domain.Contracts.Common;
using SmitenightApp.Domain.Contracts.Smitenights;

namespace SmitenightApp.Client.Interfaces;

public interface ISmitenightClient
{
    Task<ServerResponseDto<SmitenightDto>> StartSmitenightAsync(SmitenightProcessDto requestDto, CancellationToken cancellationToken = default);
    Task<ServerResponseDto<SmitenightDto>> EndSmitenightAsync(SmitenightProcessDto requestDto, CancellationToken cancellationToken = default);
}