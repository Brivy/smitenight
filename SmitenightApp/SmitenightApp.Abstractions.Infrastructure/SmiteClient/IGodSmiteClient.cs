using SmitenightApp.Domain.Clients.SmiteClient.Requests.GodRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.GodResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IGodSmiteClient
{
    Task<SmiteClientListResponse<GodsResponse>?> GetGodsAsync(
        GodsRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodLeaderbordResponse>?> GetGodLeaderbordAsync(
        GodLeaderboardRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodAltAbilitiesResponse>?> GetGodAltAbilitiesAsync(
        GodAltAbilitiesRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodSkinsResponse>?> GetGodSkinsAsync(
        GodSkinsRequest request, CancellationToken cancellationToken);
}