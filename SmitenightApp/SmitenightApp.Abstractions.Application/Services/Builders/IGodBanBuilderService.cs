using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Models.Gods;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IGodBanBuilderService
{
    Task<List<GodBan>> BuildAsync(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default);
}