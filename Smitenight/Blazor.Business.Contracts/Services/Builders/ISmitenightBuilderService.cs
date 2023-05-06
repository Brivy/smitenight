using Smitenight.Domain.Models.Clients.RetrievePlayerClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Builders;

public interface ISmitenightBuilderService
{
    Domain.Models.Models.Smitenights.Smitenight Build(PlayerResponse playerResponse, string? pinCode);
    Domain.Models.Models.Smitenights.Smitenight Build(int playerId, string? pinCode);
}