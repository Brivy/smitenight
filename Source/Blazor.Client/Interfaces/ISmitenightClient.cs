using Smitenight.Domain.Models.Contracts.Common;
using Smitenight.Domain.Models.Contracts.Smitenights;

namespace Smitenight.Presentation.Blazor.Client.Interfaces;

public interface ISmitenightClient
{
    Task<ServerResponseDto<SmitenightDto>> StartSmitenightAsync(SmitenightProcessDto requestDto, CancellationToken cancellationToken = default);
    Task<ServerResponseDto<SmitenightDto>> EndSmitenightAsync(SmitenightProcessDto requestDto, CancellationToken cancellationToken = default);
}