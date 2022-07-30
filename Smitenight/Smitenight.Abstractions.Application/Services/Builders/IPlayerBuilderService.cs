using Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses;
using Smitenight.Domain.Models.Players;

namespace Smitenight.Abstractions.Application.Services.Builders;

public interface IPlayerBuilderService
{
    Player Build(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default);
    Player BuildAnonymous(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default);
}