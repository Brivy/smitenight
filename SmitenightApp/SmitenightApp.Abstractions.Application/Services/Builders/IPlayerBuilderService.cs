using SmitenightApp.Domain.Clients.MatchClient;
using SmitenightApp.Domain.Models.Players;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IPlayerBuilderService
{
    Player Build(MatchDetailsResponse matchDetailsResponse);
    Player BuildAnonymous(MatchDetailsResponse matchDetailsResponse);
}