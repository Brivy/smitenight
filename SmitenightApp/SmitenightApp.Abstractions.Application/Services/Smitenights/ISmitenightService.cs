using SmitenightApp.Domain.Models.Common;
using SmitenightApp.Domain.Models.Smitenights;

namespace SmitenightApp.Abstractions.Application.Services.Smitenights;

public interface ISmitenightService
{
    Task<ServerResponse<Smitenight>> StartSmitenightAsync(string playerName, CancellationToken cancellationToken = default);
    Task<ServerResponse<Smitenight>> EndSmitenightAsync(string playerName, CancellationToken cancellationToken = default);
}