using Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.GodResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface IGodSmiteClient
{
    Task<SmiteClientListResponse<GodResponse>?> GetGodsAsync(
        GodRequest godRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodLeaderbordResponse>?> GetGodLeaderbordAsync(
        GodLeaderboardRequest godLeaderboardRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodAltAbilitiesResponse>?> GetGodAltAbilitiesAsync(
        GodAltAbilitiesRequest godAltAbilitiesRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodSkinsResponse>?> GetGodSkinsAsync(
        GodSkinsRequest godSkinsRequest, CancellationToken cancellationToken);
}