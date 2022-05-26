using Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.GodResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

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