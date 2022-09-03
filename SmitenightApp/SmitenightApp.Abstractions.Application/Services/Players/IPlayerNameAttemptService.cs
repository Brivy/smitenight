namespace SmitenightApp.Application.Services.Players;

public interface IPlayerNameAttemptService
{
    Task RegisterNotFoundPlayerNameAsync(string playerName, CancellationToken cancellationToken = default);
    Task<bool> PlayerNameAlreadyTriedAsync(string playerName, CancellationToken cancellationToken = default);
}