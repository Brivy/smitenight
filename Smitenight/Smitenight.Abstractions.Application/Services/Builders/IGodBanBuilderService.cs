using Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses;
using Smitenight.Domain.Models.Gods;

namespace Smitenight.Abstractions.Application.Services.Builders;

public interface IGodBanBuilderService
{
    Task<List<GodBan>> BuildAsync(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default);
}