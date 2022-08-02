using SmitenightApp.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses;
using SmitenightApp.Domain.Models.Smitenights;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface ISmitenightBuilderService
{
    Smitenight Build(PlayerResponse playerResponse);
    Smitenight Build(int playerId);
}