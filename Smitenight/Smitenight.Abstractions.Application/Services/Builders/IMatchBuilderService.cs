using Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses;
using Smitenight.Domain.Models.Matches;

namespace Smitenight.Abstractions.Application.Services.Builders;

public interface IMatchBuilderService
{
    Match Build(MatchDetailsResponse matchDetails);
}