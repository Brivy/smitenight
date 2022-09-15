using SmitenightApp.Domain.Clients.RetrievePlayerClient;
using SmitenightApp.Domain.Models.Smitenights;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface ISmitenightBuilderService
{
    Smitenight Build(PlayerResponse playerResponse, string? pinCode);
    Smitenight Build(int playerId, string? pinCode);
}