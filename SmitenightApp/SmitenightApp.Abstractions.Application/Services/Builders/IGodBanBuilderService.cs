using SmitenightApp.Domain.Clients.MatchClient;
using SmitenightApp.Domain.Models.Gods;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IGodBanBuilderService
{
    Task<List<GodBan>> BuildAsync(MatchDetailsResponse matchDetailsResponse, CancellationToken cancellationToken = default);
}