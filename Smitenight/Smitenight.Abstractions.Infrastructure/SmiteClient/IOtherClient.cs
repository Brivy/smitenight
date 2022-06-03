using Smitenight.Domain.Clients.SmiteClient.Requests.OtherRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.OtherResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface IOtherClient
{
    Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(
        EsportProLeagueRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(
        MotdRequest request, CancellationToken cancellationToken);
}