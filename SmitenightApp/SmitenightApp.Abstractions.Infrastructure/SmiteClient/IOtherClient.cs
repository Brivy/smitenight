using SmitenightApp.Domain.Clients.SmiteClient.Requests.OtherRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.OtherResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IOtherClient
{
    Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(
        EsportProLeagueRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(
        MotdRequest request, CancellationToken cancellationToken);
}