using Smitenight.Domain.Models.Models.Players;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Players;

public interface IPlayerService
{
    Task<Player?> GetAlreadyExistingAsync(string playerName, CancellationToken cancellationToken = default);
}