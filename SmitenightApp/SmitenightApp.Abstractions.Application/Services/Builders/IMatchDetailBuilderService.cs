using SmitenightApp.Domain.Clients.MatchClient;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IMatchDetailBuilderService
{
    MatchDetail Build(MatchDetailsResponse matchDetailsResponse);
}