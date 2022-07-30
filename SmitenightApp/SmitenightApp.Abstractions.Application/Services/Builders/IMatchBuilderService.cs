using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IMatchBuilderService
{
    Match Build(MatchDetailsResponse matchDetails);
}