using SmitenightApp.Domain.Models.Players;

namespace SmitenightApp.Abstractions.Application.Services.Players;

public interface IPlayerService
{
    Task<Player?> GetAlreadyExistingAsync(string playerName, CancellationToken cancellationToken = default);
}