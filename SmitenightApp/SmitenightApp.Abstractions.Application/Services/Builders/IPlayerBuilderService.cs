using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Models.Players;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IPlayerBuilderService
{
    Player Build(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default);
    Player BuildAnonymous(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default);
}